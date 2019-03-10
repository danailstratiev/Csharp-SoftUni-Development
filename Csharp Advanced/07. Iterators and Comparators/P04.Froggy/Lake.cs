using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P04.Froggy
{
    public class Lake  : IEnumerable<int>
    {
        private List<int> stones;

        public Lake (params int[] stones)
        {
            this.stones = stones.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i+=2)
            {
                yield return this.stones[i];
            }

            var variousStart = stones.Count % 2 == 0
                ? stones.Count - 1
                : stones.Count - 2;

            for (int i = variousStart; i >= 0; i-=2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
    }
}
