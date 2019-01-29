using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_2_Simple_Calculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var values = input.Split(' ');

            var calculatorStack = new Stack<string>(values.Reverse());

            while (calculatorStack.Count > 1)
            {
                int firstNumber = int.Parse(calculatorStack.Pop());
                string operand = calculatorStack.Pop();
                int secondNumber = int.Parse(calculatorStack.Pop());

                switch (operand)
                {
                    case "+":
                        calculatorStack.Push((firstNumber + secondNumber).ToString());
                        break;
                    case "-":
                        calculatorStack.Push((firstNumber - secondNumber).ToString());
                        break;
                }
            }

            Console.WriteLine(calculatorStack.Pop());
        }
    }
}
