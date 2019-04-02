using SOLID.Homework.Appenders;
using SOLID.Homework.Appenders.Contracts;
using SOLID.Homework.Core;
using SOLID.Homework.Core.Contracts;
using SOLID.Homework.Layouts;
using SOLID.Homework.Layouts.Contracts;
namespace SOLID.Homework
{
    using Loggers.Contracts;
    using Loggers.Enums;
    using System;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
       public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
