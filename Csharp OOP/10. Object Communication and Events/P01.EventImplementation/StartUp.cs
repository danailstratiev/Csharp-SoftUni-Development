using System;

namespace P01.EventImplementation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var name = Console.ReadLine();

            while (name != "End")
            {
                dispatcher.Name = name;


                name = Console.ReadLine();
            }
        }
    }
}
