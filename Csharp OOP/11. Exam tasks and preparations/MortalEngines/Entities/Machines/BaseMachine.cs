using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Machines
{
    //    A base machine should take the following values upon initialization:
    //string name, double attackPoints, double defensePoints, double healthPoints

    public abstract class BaseMachine : IMachine
    {
        private string name;
        protected double attackPoints;
        protected double defencePoints;
        private double healthPoints;
        private readonly List<string> targets;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        //TO DO ???
        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get => this.healthPoints;
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }

                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get => this.attackPoints;

            private set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get => this.defencePoints;

            private set
            {
                this.defencePoints = value;
            }
        }

        // Initiate At constructor;
        public IList<string> Targets
        {
            get => this.targets;
        }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            var damageToTake = this.AttackPoints - target.DefensePoints;

            target.HealthPoints -= damageToTake;

            this.targets.Add(target.Name);
        }

        // TO DO
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:F2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:F2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:F2}");
            sb.Append(" *Targets: ");
            if (this.targets.Count == 0)
            {
                sb.Append("None");
            }
            else
            {
                sb.Append(string.Join(",", this.targets));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
