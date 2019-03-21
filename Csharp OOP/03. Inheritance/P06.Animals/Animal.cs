using System;
using System.Collections.Generic;
using System.Text;

namespace P06.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (value == null || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;

            private set
            {
                if (value == null || string.IsNullOrEmpty(value) || (value != "Male" && value != "Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "Bau!";
        }

        public override string ToString()
        {
            return  $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
