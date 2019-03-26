using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; private set; }

        public void CompleteMission(Mission mission)
        {
            mission.State = "Finished";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }

            return base.ToString() + Environment.NewLine  +
                sb.ToString().Trim();
        }
    }
}
