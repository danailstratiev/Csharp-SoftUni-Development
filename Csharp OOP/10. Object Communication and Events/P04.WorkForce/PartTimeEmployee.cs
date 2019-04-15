using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce
{
    public class PartTimeEmployee : IEmployee
    {
        private const int PartWorkTime = 20;

        public PartTimeEmployee(string name)
        {
           this.Name = name;
           this.WorkHours = PartWorkTime;
        }

        public string Name { get; private set; }

        public int WorkHours { get; private set; }
    }
}
