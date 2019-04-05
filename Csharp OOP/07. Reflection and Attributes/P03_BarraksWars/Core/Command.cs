namespace P03_BarraksWars.Core
{
    using _03BarracksFactory.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public string[] Data { get => data; protected set => data = value; }
        public IRepository Repository { get => repository; protected set => repository = value; }
        public IUnitFactory UnitFactory { get => unitFactory; protected set => unitFactory = value; }

        public abstract string Execute();
    }
}
