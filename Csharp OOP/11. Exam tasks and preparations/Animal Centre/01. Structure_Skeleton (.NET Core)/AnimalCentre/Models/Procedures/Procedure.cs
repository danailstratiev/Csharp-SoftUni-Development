using AnimalCentre.Models.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected HashSet<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new HashSet<IAnimal>();
        }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var animal in procedureHistory)
            {
                sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            throw new NotImplementedException();
        }
    }
}
