using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_05_Calculate_Sequence_With_A_Queue
{
    class CalculateSequenceWithAQueue
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var finalSequence = new List<long>();

            queue.Enqueue(n);
            // We will keep the sequence of elements in a List
            finalSequence.Add(n);

            // We loop till 17, because 50/3 is almost 17 and we will add 3 numbers
            // on every rotation
            for (int i = 0; i < 17; i++)
            {
                var currentNumber = queue.Dequeue();

                var a = currentNumber + 1;
                var b = currentNumber * 2 + 1;
                var c = currentNumber + 2;

                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                finalSequence.Add(a);
                finalSequence.Add(b);
                finalSequence.Add(c);
            }

            Console.WriteLine(string.Join(" ", finalSequence.Take(50)));
        }
    }
}
