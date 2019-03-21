using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P03.Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;

           private set
            {
                if ((value.Length < 5 || value.Length > 10) ||
                    value.All(x => char.IsLetterOrDigit(x)) == false)
                {
                    Exception ex = new ArgumentException("Invalid faculty number!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Faculty number: {this.FacultyNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
