namespace P03_BarraksWars.Core
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName + "command");

            IExecutable execute = (IExecutable)Activator.CreateInstance(type, new object[]
            {data, this.repository, this.unitFactory });

            return execute;
        }
    }
}
