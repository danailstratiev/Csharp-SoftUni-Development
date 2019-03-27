using System;

namespace P10.ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "End")
            {
                var personInfo = input.Split();
                var name = personInfo[0];
                var country = personInfo[1];
                var age = int.Parse(personInfo[2]);

                var citizen = new Citizen(name, age, country);

                Console.WriteLine(citizen);

                input = Console.ReadLine();
            }
        }
    }
}
