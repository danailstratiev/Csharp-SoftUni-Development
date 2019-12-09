namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(List<ExportProjectDto>),
                               new XmlRootAttribute("Projects"));

            var projects = context.Projects.Where(p => p.Tasks.Count > 0).ToList();

            var exportProjects = new List<ExportProjectDto>();

            foreach (var project in projects)
            {
                var hasEndDate = string.Empty;

                if (project.DueDate == null)
                {
                    hasEndDate = "No";
                }
                else
                {
                    hasEndDate = "Yes";
                }

                var exportProject = new ExportProjectDto
                {
                    TasksCount = project.Tasks.Count().ToString(),
                    ProjectName = project.Name,
                    HasEndDate = hasEndDate
                };

                var exportTasks = project.Tasks.Select(t => new ExportTaskDto
                {
                    Name = t.Name,
                    Label = t.LabelType.ToString()
                })
                .OrderBy(t => t.Name)
                .ToList();

                exportProject.Tasks = exportTasks;

                exportProjects.Add(exportProject);
            }

            exportProjects = exportProjects.OrderByDescending(e => int.Parse(e.TasksCount))
                                           .ThenBy(e => e.ProjectName)
                                           .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (var writer = new StringWriter(sb))
            {
                xmlSerializer.Serialize(writer, exportProjects, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationResult, true);
            return result;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks.Select(t => t.Task).Any(y => y.OpenDate >= date))
                .ToList();

            var employeesToExport = new List<ExportEmployeeDto>();

            foreach (var employee in employees)
            {
                var tasks = employee.EmployeesTasks.Select(t => t.Task).Where(d => d.OpenDate >= date).ToList();

                var exportTasksDto = new List<ExportJsonTask>();

                foreach (var task in tasks.OrderByDescending(t => t.DueDate).ThenBy(t => t.Name))
                {
                    var exportTask = new ExportJsonTask
                    {
                        TaskName = task.Name,
                        OpenDate = task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = task.LabelType.ToString(),
                        ExecutionType = task.ExecutionType.ToString()
                    };

                    exportTasksDto.Add(exportTask);
                }

                var employeeDto = new ExportEmployeeDto
                {
                    Username = employee.Username,
                    Tasks = exportTasksDto
                };

                employeesToExport.Add(employeeDto);
            }

            employeesToExport = employeesToExport.OrderByDescending(e => e.Tasks.Count())
                                                 .ThenBy(e => e.Username)
                                                 .Take(10)
                                                 .ToList();

            var json = JsonConvert.SerializeObject(employeesToExport, Formatting.Indented);

            return json;
        }
    }
}