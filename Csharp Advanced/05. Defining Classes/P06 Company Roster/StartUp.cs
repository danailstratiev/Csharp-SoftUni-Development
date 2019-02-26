using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var employees = new Dictionary<string, List<Employee>>();
            var demoCalculator = new Dictionary<string, List<decimal>>();
            var allWorkers = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                //Yovcho 610.13 Manager Sales
                //Pesho 120.00 Dev Development pesho@abv.bg 28
                var input = Console.ReadLine();
                var currentEmployee = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var name = currentEmployee[0];
                var salary = decimal.Parse(currentEmployee[1]);
                var position = currentEmployee[2];
                var department = currentEmployee[3];
                var email = "n/a";
                var age = -1;

                if (!demoCalculator.ContainsKey(department))
                {
                    demoCalculator[department] = new List<decimal>();
                    demoCalculator[department].Add(salary);
                }
                else
                {
                    demoCalculator[department].Add(salary);
                }

                if (!employees.ContainsKey(department))
                {
                    employees[department] = new List<Employee>();
                }


                if (currentEmployee.Length == 6)
                {
                    email = currentEmployee[4];
                    age = int.Parse(currentEmployee[5]);
                }
                else if (currentEmployee.Length == 5)
                {
                    if (int.TryParse(currentEmployee[4], out int result))
                    {
                        age = result;
                    }
                    else
                    {
                        email = currentEmployee[4];
                    }
                }
                

                var emplpyee = new Employee(name, salary, position, department);
                emplpyee.Email = email;
                emplpyee.Age = age;

                employees[department].Add(emplpyee);
                allWorkers.Add(emplpyee);
            }
            //sorted by salary in descending order

            var topDepartment = allWorkers.GroupBy(x => x.Department).
                ToDictionary(x => x.Key, y => y.Select(s => s)).
                OrderByDescending(x => x.Value.Average(s => s.Salary)).
                FirstOrDefault();


            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");
            foreach (var worker in topDepartment.Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{worker.Name} {worker.Salary:F2} {worker.Email} {worker.Age}");
            }
        }
        public static string CalculateAverageSalary(Dictionary<string, List<decimal>> demo)
        {
            var demoCalculator = demo.OrderByDescending(x => x.Value.Average()).FirstOrDefault().Key;

            return demoCalculator;
        }
    }
}
