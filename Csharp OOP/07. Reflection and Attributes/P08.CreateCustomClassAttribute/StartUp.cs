using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace P08.CreateCustomClassAttribute
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var type = typeof(GoldMemberAttribute);
            var goldMember = (GoldMemberAttribute)Activator.CreateInstance(type);

            var input = Console.ReadLine();

            while (input != "END")
            {
                var currentInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.Static).
                    First(x => x.Name == input);

                if (input != "Description")
                {
                    Console.WriteLine($"{currentInfo.Name}: {currentInfo.GetValue(goldMember)}");
                }
                else
                {
                    Console.WriteLine($"Class description: {currentInfo.GetValue(goldMember)}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
