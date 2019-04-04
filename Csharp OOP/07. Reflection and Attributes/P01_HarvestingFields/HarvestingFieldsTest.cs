 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance);

            var input = Console.ReadLine();

            while (input != "HARVEST")
            {
                if (input != "all")
                {
                    var fieldsToPrint = fields.
                        Where(x => x.Attributes.ToString().ToLower().Replace("family", "protected") == input).
                        ToArray();

                    foreach (var field in fieldsToPrint)
                    {
                        var fieldModifier = field.Attributes.ToString().ToLower().Replace("family", "protected");
                        Console.WriteLine($"{fieldModifier} {field.FieldType.Name} {field.Name}");
                    }
                }
                else
                {
                    foreach (var field in fields)
                    {
                        var fieldModifier = field.Attributes.ToString().ToLower().Replace("family", "protected");
                        Console.WriteLine($"{fieldModifier} {field.FieldType.Name} {field.Name}");
                    }
                }

                input = Console.ReadLine();
            }
        }       
    }
}
