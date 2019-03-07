using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace P03.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();
    }
}
