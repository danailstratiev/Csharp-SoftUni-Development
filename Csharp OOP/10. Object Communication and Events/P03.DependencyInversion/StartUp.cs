using System;
using System.Linq;
using System.Collections.Generic;

namespace P03_DependencyInversion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var calculator = new PrimitiveCalculator();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (char.IsDigit(input[0]) || input[0] == '-')
                {
                    var numbers = input.Split().Select(int.Parse).ToArray();

                    var firstOperand = numbers[0];
                    var secondOperand = numbers[1];

                    Console.WriteLine(calculator.PerformCalculation(firstOperand, secondOperand));
                }
                else
                {
                    var operation = input.Split();

                    var @operator = operation[1];

                    IStrategy strategy = null;

                    switch (@operator)
                    {
                        case "+":
                            strategy = new AdditionStrategy();
                            break;
                        case "-":
                            strategy = new SubtractionStrategy();
                            break;
                        case "*":
                            strategy = new MultiplyStrategy();
                            break;
                        case "/":
                            strategy = new DivideStrategy();
                            break;
                    }

                    calculator.ChangeStrategy(strategy);
                }
            }
        }
    }
}
