using System;
using System.Linq;
using System.Collections.Generic;


namespace P03.Mankind
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            var studentInput = Console.ReadLine().Split(" ").ToArray();
            var student = new Student(studentInput[0], studentInput[1], studentInput[2]);

            var workerInput = Console.ReadLine().Split(" ").ToArray();
            var weekSalary = decimal.Parse(workerInput[2]);
            var workHoursPerDay = decimal.Parse(workerInput[3]);
            var worker = new Worker(workerInput[0], workerInput[1], weekSalary, workHoursPerDay);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
    }
}
