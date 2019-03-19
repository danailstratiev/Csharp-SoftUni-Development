using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P02.BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public virtual string Title
        {
            get => this.title;


            set
            {
                if (value.Length < 3)
                {
                    Exception ex = new ArgumentException("Title not valid!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                this.title = value;
            }
        }

        public virtual string Author
        {
            get => this.author;

            set
            {
                if (this.ValidateName(value) == true)
                {
                    Exception ex = new ArgumentException("Author not valid!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;

            set
            {
                if (value <= 0)
                {
                    Exception ex = new ArgumentException("Price not valid!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.price = value;
            }
        }

        public bool ValidateName(string authorName)
        {
            var authorInput = authorName.Split(" ").ToArray();

            if (authorInput.Length == 1)
            {
                return false;
            }
            var authorSecondName = authorInput[1];
            var firstLetter = authorSecondName[0];

            return char.IsDigit(firstLetter);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Type: {this.GetType().Name}");
            result.AppendLine($"Title: {this.Title}");
            result.AppendLine($"Author: {this.Author}");
            result.AppendLine($"Price: {this.Price:f2}");
            return result.ToString();
        }
    }
}
