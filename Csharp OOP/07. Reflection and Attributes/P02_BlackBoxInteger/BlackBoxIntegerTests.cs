namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);

            var box = (BlackBoxInteger)Activator.CreateInstance(type, true);

            var input = Console.ReadLine();

            while (input != "END")
            {
                var command = input.Split("_")[0];
                var number = int.Parse(input.Split("_")[1]);

                var method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(x => x.Name == command);

                method.Invoke(box, new object[] { number });

                var fieldValue = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(x => x.Name == "innerValue").GetValue(box);

                Console.WriteLine(fieldValue);

                input = Console.ReadLine();
            }
        }
    }
}
