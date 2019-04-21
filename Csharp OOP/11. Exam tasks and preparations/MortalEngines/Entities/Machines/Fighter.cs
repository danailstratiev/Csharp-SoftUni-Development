using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200;
        private bool aggressiveMode;
        private const bool DefaultAggressiveModeValue = true;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.AggressiveMode = DefaultAggressiveModeValue;
            this.attackPoints += 50;
            this.defencePoints -= 25;
        }

        public bool AggressiveMode
        {
            get => this.aggressiveMode;

            private set
            {
                this.aggressiveMode = value;
            }
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AggressiveMode = false;
            }
            else
            {
                this.AggressiveMode = true;
            }

            if (this.AggressiveMode == true)
            {
                this.attackPoints += 50;
                this.defencePoints -= 25;
            }
            else
            {
                this.attackPoints -= 50;
                this.defencePoints += 25;
            }
        }

        public override string ToString()
        {
            var aggressiveModeMessage = string.Empty;

            if (this.AggressiveMode == true)
            {
                aggressiveModeMessage = " *Aggressive: ON";
            }
            else
            {
                aggressiveModeMessage = " *Aggressive: OFF";
            }

            return base.ToString() + Environment.NewLine + aggressiveModeMessage;
        }
    }
}
