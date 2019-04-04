using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        var type = Type.GetType(className);
        var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public |
            BindingFlags.Instance | BindingFlags.Static);
        var sb = new StringBuilder();

        foreach (var method in methods.Where(x => x.Name.Contains("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(x => x.Name.Contains("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }
        return sb.ToString().Trim();
    }
}

