using System;

namespace P03.Ferrari
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var ferrari = new MyFerrari(name);
            Console.WriteLine(ferrari);
        }
    }
}
