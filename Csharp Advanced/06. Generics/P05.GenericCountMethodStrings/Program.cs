using System;
using System.Linq;
using System.Collections.Generic;


namespace P05.GenericCountMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var myBox = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                myBox.Add(line);
            }

            var wantedItem = Console.ReadLine();

            Console.WriteLine(GetCountOfGreaterElements(myBox.Items, wantedItem));
        }

        public static int GetCountOfGreaterElements<T>(List<T> items, T wantedItem)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in items)
            {
                //CompareTo returns -1 , 0 or 1 if the item is smaller, equal ot larger than the wantedItem
                if (item.CompareTo(wantedItem) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
