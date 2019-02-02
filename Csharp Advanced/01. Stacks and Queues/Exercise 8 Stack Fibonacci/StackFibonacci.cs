using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_8_Stack_Fibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var fibonacciStack = new Stack<long>();

            long firstNum = 0;
            long firstNum1 = 1;

            fibonacciStack.Push(firstNum);
            fibonacciStack.Push(firstNum1);

            for (int i = 0; i < n-2; i++)
            {
                firstNum = firstNum1;
                firstNum1 = fibonacciStack.Sum();

                fibonacciStack.Pop();
                fibonacciStack.Pop();

                fibonacciStack.Push(firstNum);
                fibonacciStack.Push(firstNum1);
            }

            Console.WriteLine(fibonacciStack.Sum());

        }
    }
}
