using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library()
        {
            this.books = new SortedSet<Book>(new BookComparer());
        }

        public void Add(Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in this.books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    }
}
