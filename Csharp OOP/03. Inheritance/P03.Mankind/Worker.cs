using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Mankind
{
    public class Worker : Human
    {
        public const string mismatchMessage = "Expected value mismatch! Argument: {0}";
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get => this.weekSalary;

           private set
            {
                if (value <= 10m)
                {
                    Console.WriteLine(mismatchMessage, nameof(this.weekSalary));
                    Environment.Exit(0);
                }
                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get => this.workHoursPerDay;

           private set
            {
                if (value < 1 || value > 12)
                {
                    Console.WriteLine(mismatchMessage, nameof(this.workHoursPerDay));
                    Environment.Exit(0);
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal SalaryPerHour()
        {
            return (this.WeekSalary ) / (this.WorkHoursPerDay * 5);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Week Salary: {this.WeekSalary:F2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}")
            .AppendLine($"Salary per hour: {this.SalaryPerHour():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
