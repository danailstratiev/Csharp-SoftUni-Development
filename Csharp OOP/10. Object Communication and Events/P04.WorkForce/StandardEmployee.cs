using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WorkForce
{
    public class StandardEmployee : IEmployee
    {
        private const int StandardWorkTime = 40;

        public StandardEmployee(string name)
        {
            this.Name = name;
            this.WorkHours = StandardWorkTime;
        }

        public string Name { get; private set; }

        public int WorkHours { get; private set; }
    }
}
