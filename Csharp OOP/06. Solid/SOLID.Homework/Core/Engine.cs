using SOLID.Homework.Core.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Homework.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var appenderInput = Console.ReadLine().Split();

                this.commandInterpreter.AddAppender(appenderInput);
            }

            var input = Console.ReadLine();

            while (input != "END")
            {
                var reportInput = input.Split("|");

                this.commandInterpreter.AddReport(reportInput);

                input = Console.ReadLine();
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
