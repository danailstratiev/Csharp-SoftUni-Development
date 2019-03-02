using System;

namespace P02._2.GenericBoxOfInteger
{
   public class Program
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                var box = new Box<int>(currentNumber);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
