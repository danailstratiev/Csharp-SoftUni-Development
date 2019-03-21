using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P03.Mankind
{
    public class Human
    {
        public const string invalidNameMessage = "Expected upper case letter! Argument: {0}";
        public const string invalidNameLength = "Expected length at least {0} symbols! Argument: {1}";

        private string firstName;

        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;

           private set
            {
                if (!char.IsUpper(value[0]))
                {
                    Console.WriteLine(invalidNameMessage, nameof(this.firstName));
                    Environment.Exit(0);
                }

                if (value.Length < 4)
                {
                    Console.WriteLine(invalidNameLength, 4, nameof(this.firstName));                   
                    Environment.Exit(0);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName; 

           private set
            {
                if (!char.IsUpper(value[0]))
                {
                    Console.WriteLine(invalidNameMessage, nameof(this.lastName));
                    Environment.Exit(0);
                }

                if (value.Length < 3)
                {
                    Console.WriteLine(invalidNameLength, 3, nameof(this.lastName));
                    Environment.Exit(0);
                }
                this.lastName = value;
            }
        }
    }
}
