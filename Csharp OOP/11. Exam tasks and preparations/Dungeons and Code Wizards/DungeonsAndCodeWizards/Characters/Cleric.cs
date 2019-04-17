using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Bags;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double baseHealth = 50;
        private const double baseArmor = 25;
        private const double abilityPoints = 40;
        private const double restHealMultiplier = 0.5;

        public Cleric(string name, Faction faction)
            : base(name, baseHealth, baseArmor, abilityPoints, new Backpack(), faction)
        {
            this.BaseHealth = baseHealth;
            this.BaseArmor = baseArmor;
            this.AbilityPoints = abilityPoints;
            this.RestHealMultiplier = restHealMultiplier;
        }

        public void Heal(Character character)
        {
            this.ValidateLifeStatus();
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character.Faction == this.Faction)
            {
                throw new InvalidOperationException($"Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;

            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
