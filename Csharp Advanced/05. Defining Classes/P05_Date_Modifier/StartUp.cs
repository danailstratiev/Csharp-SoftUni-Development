using P05_Date_Modifier;
using System;
using System.Globalization;


namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            var dateMod = new DateModifier();
            dateMod.FirstDate = firstDate;
            dateMod.SecondDate = secondDate;

            var myTime = Math.Abs(dateMod.DateDifference().TotalDays);

            Console.WriteLine(myTime);
        }
    }
}
