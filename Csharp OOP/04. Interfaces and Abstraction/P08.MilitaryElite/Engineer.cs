using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }            

            return base.ToString() + Environment.NewLine + sb.ToString().Trim();
        }
    }
}
