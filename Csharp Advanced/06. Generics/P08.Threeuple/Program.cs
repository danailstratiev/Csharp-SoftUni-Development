using System;
using System.Linq;
using System.Collections.Generic;


namespace P08.Threeuple
{
   public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine().Split(" ").ToArray();

                switch (i)
                {
                    case 0:
                        var name = $"{input[0]} {input[1]}";
                        var adress = input[2];
                        var tuple = new Threeuple<string, string, string>(name, adress, input[3]);
                        Console.WriteLine(tuple);
                        break;
                    case 1:
                        var anotherName = input[0];
                        var status = input[2];
                        var isDrunk = status == "drunk" ? true : false ;
                        var tuple1 = new Threeuple <string, int, bool>(anotherName, int.Parse(input[1]), isDrunk);
                        Console.WriteLine(tuple1);
                        break;
                    case 2:
                        var someName = input[0];
                        var accountBalance = double.Parse(input[1]);
                        var tuple2 = new Threeuple <string,double, string>(someName, accountBalance, input[2]);
                        Console.WriteLine(tuple2);
                        break;
                }
            }
        }
    }
}
