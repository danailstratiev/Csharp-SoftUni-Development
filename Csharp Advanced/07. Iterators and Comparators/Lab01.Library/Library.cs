using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public void Add (Book book)
        {
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryEnumerator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

        private class LibraryEnumerator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;

            public LibraryEnumerator(List<Book> books)
            {
                this.books = books;
                this.index = -1;
            }

            public Book Current
            {
                get
                {
                    return this.books[index];
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public IEnumerator<Book> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                this.index++;

                if (this.index < this.books.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
