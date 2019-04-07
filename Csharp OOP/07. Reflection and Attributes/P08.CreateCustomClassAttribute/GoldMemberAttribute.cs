using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CreateCustomClassAttribute
{
    public class GoldMemberAttribute : Attribute
    {
        private const string author = "Pesho";
        private const int revision = 3;
        private const string description = "Used for C# OOP Advanced Course - Enumerations and Attributes.";
        private const string reviewers = "Pesho, Svetlio";

        public GoldMemberAttribute()
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }

        public string Author { get; }

        public int Revision { get; }

        public string Description {get;}

        public string Reviewers { get; }
    }
}
