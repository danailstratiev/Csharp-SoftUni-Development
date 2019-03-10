using System;
using System.Linq;
using System.Collections.Generic;


namespace P04.Froggy
{
   public class Program
    {
        static void Main(string[] args)
        {
            var jumpNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var lake = new Lake(jumpNumbers);
                        
            Console.WriteLine(string.Join(", ", lake));
            
        }
    }
}
