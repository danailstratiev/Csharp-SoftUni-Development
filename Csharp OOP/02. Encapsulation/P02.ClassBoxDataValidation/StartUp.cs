using System;
using System.Linq;
using System.Collections.Generic;


namespace P02.ClassBoxDataValidation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var length = decimal.Parse(Console.ReadLine());
            var width = decimal.Parse(Console.ReadLine());
            var height = decimal.Parse(Console.ReadLine());
            var box = new Box(length, width, height);


            Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.CalculateVolume():F2}");
        }
    }
}
