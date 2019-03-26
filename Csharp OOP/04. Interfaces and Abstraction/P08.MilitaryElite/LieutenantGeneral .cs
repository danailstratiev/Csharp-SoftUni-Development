using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P08.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<Private>();
        }

        public List<Private> Privates { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Privates:");
            foreach (var soldier in this.Privates)
            {
                sb.AppendLine("  " + soldier.ToString());
            }

            return base.ToString() + Environment.NewLine + sb.ToString().Trim();
        }
    }
}
