using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P01.Database
{
    public class Database
    {
        private const int MaxArraySize = 16;
        private int[] numbers;
        private int index;

        public Database()
        {
            this.numbers = new int[MaxArraySize];
            this.index = 0;
        }

        public Database(int[] integers)
        {
            if (integers.Length != MaxArraySize)
            {
                throw new InvalidOperationException($"Array length must be exactly {MaxArraySize}!");
            }

            this.numbers = integers;
            this.index = integers.Length - 1;
        }

        public void Add (int value)
        {
            if (this.index < value)
            {
                this.numbers[++this.index] = value;
            }

            throw new InvalidOperationException("Database is full!");
        }

        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.numbers[index] = 0;
            this.index--;
        }

        public int[] Fetch()
        {
           return this.numbers.Take(this.index + 1).ToArray();
        }
    }
}
