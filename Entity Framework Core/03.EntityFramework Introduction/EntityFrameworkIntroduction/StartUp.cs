using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                Console.WriteLine(RemoveTown(context));
            }
        }


        // Problem 3.Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary,
                e.EmployeeId
            }).OrderBy(x => x.EmployeeId).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 4.Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(x => x.Salary > 50000).OrderBy(x => x.FirstName).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 5.Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 6.Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);
            // Дори и да не добавим адреса, Entity Framework ще го добави
            // щом види промяната в currentEmployee.Address

            var currentEmployee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            currentEmployee.Address = address;

            context.SaveChanges();

            var sb = new StringBuilder();

            var employeeAddresses = context.Employees.OrderByDescending(x => x.AddressId)
                .Select(a => a.Address.AddressText)
                .Take(10).ToList();

            foreach (var employeeAddress in employeeAddresses)
            {
                sb.AppendLine(employeeAddress);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 7.Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(p => p.EmployeesProjects.Any(s => s.Project.StartDate.Year >= 2001 && s.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFullName = x.FirstName + " " + x.LastName,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    }).ToList()
                }).Take(10).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeFullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                        CultureInfo.InvariantCulture);
                    var endDate = project.EndDate.HasValue ?
                        project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt",
                        CultureInfo.InvariantCulture)
                        : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8.Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses.Select(x => new
            {
                EmployeesCount = x.Employees.Count,
                TownName = x.Town.Name,
                AddressText = x.AddressText
            })
                .OrderByDescending(x => x.EmployeesCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                sb.Append($"{address.AddressText}, ");
                sb.Append($"{address.TownName} - ");
                sb.Append($"{address.EmployeesCount} employees");
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9.Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees
                .FirstOrDefault(x => x.EmployeeId == 147);

            sb.AppendLine($"{employee.FirstName + " " + employee.LastName} - {employee.JobTitle}");

            var projectsIds =
                context.EmployeesProjects.Where(x => x.EmployeeId == employee.EmployeeId)
                .Select(x => x.ProjectId ).ToList();               
            

            var projects = context.Projects.Where(x => projectsIds.Contains(x.ProjectId));

            foreach (var project in projects.OrderBy(x => x.Name))
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10.Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments.Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Employees = x.Employees.Select(e => new
                    {
                        EmployeeFullName = e.FirstName + " " + e.LastName,
                        JobTitle = e.JobTitle
                    }).OrderBy(f => f.EmployeeFullName)
                });

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");
                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11.Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.OrderByDescending(x => x.StartDate).Take(10);

            var sb = new StringBuilder();

            foreach (var project in projects.OrderBy(x => x.Name))
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                        CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12.Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var deps = new[]
            {
                "Engineering","Tool Design","Marketing","Information Services"
            };
            var employees = context.Employees.Where(x => deps.Contains(x.Department.Name));

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employeesToPrint = employees.Select(x => new
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Salary = x.Salary
            })
              .OrderBy(x => x.FirstName)
              .ThenBy(x => x.LastName);

            foreach (var employee in employeesToPrint)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 13.Find Employees by First Name Starting With "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(x => x.FirstName.StartsWith("Sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                }).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14.Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var project = context.Projects.FirstOrDefault(x => x.ProjectId == 2);

            var employeeProjects = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();

            context.EmployeesProjects.RemoveRange(employeeProjects);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects
                .Select(x => x.Name)
                .Take(10)
                .ToList();

            foreach (var proj in projects)
            {
                sb.AppendLine(proj);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15.Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var seattle = context.Towns.First(t => t.Name == "Seattle");

            var addressesInTown = context.Addresses.Where(a => a.Town.Name == "Seattle");

            var employeesToRemoveAddress = context.Employees.Where(e => addressesInTown.Contains(e.Address));

            foreach (var e in employeesToRemoveAddress)
            {
                e.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesInTown);

            //foreach (var a in addressesInTown)
            //{
            //    context.Addresses.Remove(a);
            //}

            int addressesCount = addressesInTown.Count();

            context.Towns.Remove(seattle);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
