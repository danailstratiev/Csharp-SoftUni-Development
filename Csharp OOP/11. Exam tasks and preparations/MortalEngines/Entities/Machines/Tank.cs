using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Machines
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;
        private bool defenseMode;
        private const bool DefaultDefenseModeValue = true;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.DefenseMode = DefaultDefenseModeValue;
            this.attackPoints -= 40;
            this.defencePoints += 30;
        }

        public bool DefenseMode
        {
            get => this.defenseMode;

            private set
            {
                this.defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
            }
            else
            {
                this.DefenseMode = true;
            }

            if (this.DefenseMode == true)
            {
                this.attackPoints -= 40;
                this.defencePoints += 30;
            }
            else
            {
                this.attackPoints += 40;
                this.defencePoints -= 30;
            }
        }

        public override string ToString()
        {
            var defensiveModeMessage = string.Empty;

            if (this.DefenseMode == true)
            {
                defensiveModeMessage = " *Defense: ON";
            }
            else
            {
                defensiveModeMessage = " *Defense: OFF";
            }

            return base.ToString() + Environment.NewLine + defensiveModeMessage;
        }
    }
}
