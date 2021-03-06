﻿using System;
using System.Linq;
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

    public string RevealPrivateMethods(string className)
    {
        var type = Assembly.GetExecutingAssembly().GetTypes().First(x => x.Name == className);
        var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {type.Name}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        foreach (var method in methods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }
}

