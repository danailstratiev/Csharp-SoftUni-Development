namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using BookShop.Models;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));
            }
        }

        // P01.Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            //enum.ToString returns the string value of an enum

            var books = context.Books.Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                               .Select(y => new { y.Title }).OrderBy(b => b.Title).ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        //P02.Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books.Where(x => x.EditionType.ToString() == "Gold" 
                                        && x.Copies < 5000)
                               .Select(y => new {y.BookId, y.Title }).OrderBy(b => b.BookId).ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        //P03.Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books.Where(x => x.Price > 40)
                               .Select(y => new { y.Price, y.Title }).OrderByDescending(b => b.Price).ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        //P04.Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();
            
            var books = context.Books.Where(x => x.ReleaseDate.Value.Year != year)
                              .Select(y => new { y.BookId, y.Title }).OrderBy(b => b.BookId).ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();

        }

        //P05.Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = new List<Book>();

            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower())
                                  .ToArray();

            foreach (var c in categories)
            {
                var booksToCategory = context.Books.Where(b => b.BookCategories.Select(bc =>
                                      new { bc.Category.Name })
                                      .Any(ca => ca.Name.ToLower() == c))
                                      .ToList();

                books.AddRange(booksToCategory);
            }

            foreach (var book in books.OrderBy(b => b.Title))
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().Trim();
        }

        //P06.Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var books = context.Books.Where(x => x.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                              .Select(y => new { y.Price, y.Title, EditionType = y.EditionType.ToString(), y.ReleaseDate })
                              .OrderByDescending(b => b.ReleaseDate).ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                         .Where(a => a.FirstName.Substring(a.FirstName.Length - input.Length, input.Length) == input)
                         .Select(b => new {FirstName = b.FirstName + " " + b.LastName })
                         .OrderBy(b => b.FirstName).ToList();


            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName}");
            }

            return sb.ToString().Trim();

        }
    }
}
