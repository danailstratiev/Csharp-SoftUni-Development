using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name
        {
            get => this.name;
            set
            {
                if (value.Length < 3)
                {
                    Exception ex = new ArgumentException("Name's length should not be less than 3 symbols!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public virtual int Age
        {
            get => this.age;

            set
            {
                if (value < 0)
                {
                    Exception ex = new ArgumentException("Age must be positive!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
