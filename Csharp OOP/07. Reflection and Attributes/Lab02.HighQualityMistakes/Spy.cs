using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string name, params string[] fields)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        var type = assembly.GetTypes().First(x => x.Name == name);
        var hacker = (Hacker)Activator.CreateInstance(type);
        var sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {type}");

        foreach (var field in fields)
        {
            var fieldInfo = type.GetFields(BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Public
                | BindingFlags.Static).
                First(x => x.Name == field);

            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(hacker)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var type = typeof(Hacker);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance
            | BindingFlags.Static);

        var sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        var getters = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var getter in getters.Where(x => x.Name.Contains("get")))
        {
            sb.AppendLine($"{getter.Name} have to be public!");
        }

        var setters = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        foreach (var setter in setters.Where(x => x.Name.Contains("set")))
        {
            sb.AppendLine($"{setter.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}

