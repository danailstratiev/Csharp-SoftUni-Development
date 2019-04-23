using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private string name;
        private readonly List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            var foundGladiator = this.gladiators.FirstOrDefault(x => x.Name == name);

            this.gladiators.Remove(foundGladiator);
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {           
            var foundGladiator = this.gladiators[0];

            foreach (var gladiator in this.gladiators)
            {
                if (gladiator.GetStatPower() > foundGladiator.GetStatPower())
                {
                    foundGladiator = gladiator;
                }
            }

            return foundGladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            var foundGladiator = this.gladiators[0];

            foreach (var gladiator in this.gladiators)
            {
                if (gladiator.GetStatPower() > foundGladiator.GetWeaponPower())
                {
                    foundGladiator = gladiator;
                }
            }

            return foundGladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            var foundGladiator = this.gladiators[0];

            foreach (var gladiator in this.gladiators)
            {
                if (gladiator.GetStatPower() > foundGladiator.GetTotalPower())
                {
                    foundGladiator = gladiator;
                }
            }

            return foundGladiator;
        }

        public int Count { get => this.gladiators.Count;}

        // "[Arena name] - [count of gladiators] gladiators are participating."
        public override string ToString()
        {
            return $"[{this.Name}] - [{this.gladiators.Count}] gladiators are participating.";
        }
    }
}
