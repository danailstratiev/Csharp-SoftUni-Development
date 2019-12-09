namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using System.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(List<ImportProjectDto>),
                                new XmlRootAttribute("Projects"));

            var projects = new List<Project>();

            using (var reader = new StringReader(xmlString))
            {
                var projectsFromDto = (List<ImportProjectDto>)xmlSerializer.Deserialize(reader);
                var projectTasks = new List<Task>();

                foreach (var projectDto in projectsFromDto)
                {
                    var projectOpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);

                    if (!IsValid(projectsFromDto) || !IsValid(projectOpenDate))
                    {
                        sb.AppendLine(ErrorMessage);

                        continue;
                    }

                    
                    var projectDueDate = new DateTime?();
                    if (projectDto.DueDate != string.Empty && projectDto.DueDate != null)
                    {
                        projectDueDate = DateTime.ParseExact(projectDto.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        projectDueDate = null;
                    }

                    var project = new Project
                    {
                        Name = projectDto.Name,
                        OpenDate = projectOpenDate,
                        DueDate = projectDueDate
                    };

                    foreach (var task in projectDto.Tasks)
                    {
                        if (!IsValid(task))
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }

                        var taskOpenDate = DateTime.ParseExact(task.OpenDate, "dd/MM/yyyy",
                       CultureInfo.InvariantCulture);
                        var taskDueDate = DateTime.ParseExact(task.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);

                        //TODO check date equation
                        
                        if (taskOpenDate > projectOpenDate  || projectDueDate != null 
                            && taskDueDate < projectDueDate)
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }

                        var importTask = new Task
                        {
                            Name = task.Name,
                            OpenDate = taskOpenDate,
                            DueDate = taskDueDate,
                            LabelType = (LabelType)task.LabelType,
                            ExecutionType = (ExecutionType)task.ExecutionType,
                            ProjectId = project.Id
                        };

                        project.Tasks.Add(importTask);
                        projectTasks.Add(importTask);
                    }

                    project.Tasks = projectTasks;
                    context.Tasks.AddRange(projectTasks);
                    projects.Add(project);
                    sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count()} tasks.");
                    context.Projects.Add(project);
                    context.SaveChanges();
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var importEmployees = JsonConvert.DeserializeObject<List<ImportEmployeeDto>>(jsonString);

            var sb = new StringBuilder();

            var employees = new List<Employee>();

            foreach (var dto in importEmployees)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);

                    continue;
                }

                var employee = new Employee
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    Phone = dto.Phone
                };

                dto.Tasks = dto.Tasks.Distinct().ToList();

                foreach (var task in dto.Tasks)
                {
                    var currentTask = context.Tasks.FirstOrDefault(x => x.Id == task);

                    if (currentTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeeTask = new EmployeeTask
                    {
                        EmployeeId = employee.Id,
                        TaskId = task
                    };

                    employee.EmployeesTasks.Add(employeeTask);
                    context.EmployeesTasks.Add(employeeTask);
                }

                context.Employees.Add(employee);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count()} tasks.");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}