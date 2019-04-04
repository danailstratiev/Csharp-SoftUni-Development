using System;
using System.Linq;
using System.Reflection;


public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute item in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {item.Name}");
                }
            }
        }
    }
}

