using System;
using System.Linq;
using System.Collections.Generic;


namespace IteratorsAndComparators
{
  public class StartUp
    {
        static void Main(string[] args)
        {
            var book1 = new Book("ToshkoAftikanski", 1963, "Angel Karaliichev");
            var book2 = new Book("The adventures of the little onion", 1951, "Gianni Rodari");
            var library = new Library(new Book[] { book1, book2 });
           
            foreach (var book in library)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
