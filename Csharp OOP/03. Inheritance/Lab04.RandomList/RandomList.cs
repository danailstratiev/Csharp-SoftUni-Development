using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            var index = random.Next(0, this.Count);
            var removedString = this[index];
            this.RemoveAt(index);

            return removedString;
        }
    }
}
