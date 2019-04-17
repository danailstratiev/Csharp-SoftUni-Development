using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Bags;

namespace DungeonsAndCodeWizards.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double baseHealth = 100;
        private const double baseArmor = 50;
        private const double abilityPoints = 40;

        public Warrior(string name, Faction faction) 
            : base(name, baseHealth, baseArmor, abilityPoints, new Satchel(), faction)
        {
            this.BaseHealth = baseHealth;
            this.BaseArmor = baseArmor;
            this.AbilityPoints = abilityPoints;
        }
             

        public void Attack(Character character)
        {
            this.ValidateLifeStatus();
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (character.Faction == this.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
