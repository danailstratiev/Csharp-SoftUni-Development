using System;
using System.Linq;
using System.Collections.Generic;


namespace P05.PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var pizza = Console.ReadLine().Split(" ").ToArray();
            var doughInput = Console.ReadLine().Split(" ").ToArray();

            var dough = new Dough(doughInput[1], doughInput[2], decimal.Parse(doughInput[3]));
            var myPizza = new Pizza(pizza[1], dough);

            var input = Console.ReadLine();

            while (input != "END")
            {
                var currentInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var topping = new Topping(currentInput[1], decimal.Parse(currentInput[2]));

                myPizza.Add(topping);

                input = Console.ReadLine();
            }

            Console.WriteLine(myPizza);
        }
    }
}
