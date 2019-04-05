namespace P03_BarraksWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            try
            {
                this.Repository.RemoveUnit(this.Data[1]);
                return $"{this.Data[1]} retired!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
