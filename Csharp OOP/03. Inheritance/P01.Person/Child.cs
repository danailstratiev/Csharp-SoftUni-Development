using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {

        }

        public override int Age
        {
            get => base.Age;

            set
            {                
                if (value > 15)
                {
                    Exception ex = new ArgumentException("Child's age must be less than 15!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                base.Age = value;
            }
        }
    }
}
