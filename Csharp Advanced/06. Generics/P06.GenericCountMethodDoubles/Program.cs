using System;
using System.Linq;
using System.Collections.Generic;


namespace P06.GenericCountMethodDoubles
{
   public class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            var myBox = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                var number = double.Parse(Console.ReadLine());
                myBox.Add(number);
            }

            var wantedItem = double.Parse(Console.ReadLine());

            Console.WriteLine(GetCountOfLargerElements(myBox.Items, wantedItem));

        }
        public static int GetCountOfLargerElements <T> (List<T> items, double wantedItem)
            where T : IComparable 
        {
            var count = 0;

            foreach (var item in items)
            {
                if (item.CompareTo(wantedItem) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
