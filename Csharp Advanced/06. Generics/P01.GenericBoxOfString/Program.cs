using System;
using System.Linq;
using System.Collections.Generic;


namespace P01.GenericBoxOfString
{
   public class Program
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentItem = Console.ReadLine();
                var box = new Box<string>(currentItem);

                Console.WriteLine(box.ToString());
            }
        }
    }
}
