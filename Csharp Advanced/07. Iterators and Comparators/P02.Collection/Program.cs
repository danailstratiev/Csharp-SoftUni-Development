using System;
using System.Linq;
using System.Collections.Generic;


namespace P02.Collection
{
   public class Program
    {
       public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var listylterator = new ListyIterator<string>(new List<string>());

            while (input != "END")
            {
                if (input.Contains("Create"))
                {
                    var createList = input.Split().ToArray();

                    if (createList.Length > 1)
                    {
                        for (int i = 1; i < createList.Length; i++)
                        {
                            listylterator.coolList.Add(createList[i]);
                        }
                    }
                }

                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listylterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listylterator.HasNext());
                        break;
                    case "Print":
                        Console.WriteLine(listylterator.Print());
                        break;
                    case "PrintAll":
                        Console.WriteLine(listylterator.PrintAll());
                        break;
                }

                input = Console.ReadLine();
            }
        }

        public void PrintAll (List<string> someList)
        {
            if (someList.Count > 0)
            {
                foreach (var item in someList)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
