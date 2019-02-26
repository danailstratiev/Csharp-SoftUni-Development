using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Employee
    {
        //name, salary, position and department are mandatory  
        public Employee(string name, decimal salary, string position, string department)
        {
            this.Name = name;

            this.Salary = salary;

            this.Position = position;

            this.Department = department;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
