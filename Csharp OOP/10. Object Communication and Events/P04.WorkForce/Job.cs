using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce
{
    public class Job
    {
        private IEmployee employee;
        private string name;


        public Job(IEmployee employee, string name, int hoursOfWorkRequired)
        {
            this.employee = employee;
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
        }

        public string Name { get => this.name; set => this.name = value; }

        public int HoursOfWorkRequired { get; private set; }

        public bool Update()
        {
            this.HoursOfWorkRequired -= this.employee.WorkHours;

            if (this.HoursOfWorkRequired > 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine($"Job {this.Name} done!");
                return true;
            }
        }

        public string StatusReport()
        {
            return $"Job: {this.Name} Hours Remaining: {HoursOfWorkRequired}";
        }
    }
}
