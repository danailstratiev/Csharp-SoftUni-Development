using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P08.MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corps ;

            private set
            {
                if (value != "Marines" && value != "Airforces")
                {
                    throw new ArgumentException("Invalid Corps");
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + 
                $"Corps: {this.Corps}";
        }
    }
}
