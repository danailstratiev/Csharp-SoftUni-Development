namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes().First(x => x.Name == unitType);

            IUnit unit = (IUnit)Activator.CreateInstance(type, true);

            return unit;
        }
    }
}
