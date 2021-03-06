﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P13.FamilyTree
{
   public class Result
    {
        public Result()
        {
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public Person MainPerson { get; set; }

        public List<Person> Parents { get; set; }

        public List<Person> Children { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(MainPerson.ToString());
            sb.AppendLine("Parents:");
            if (Parents.Any())
            {
                sb.AppendLine(string.Join(Environment.NewLine, Parents));
            }
            sb.AppendLine("Children:");
            if (Children.Any())
            {
                sb.AppendLine(string.Join(Environment.NewLine, Children));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
