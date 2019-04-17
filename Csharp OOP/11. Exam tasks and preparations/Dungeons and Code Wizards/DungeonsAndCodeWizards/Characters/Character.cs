using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character : ICharacter
    {
        private string name;
        private const double restHealMultiplier = 0.2;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = restHealMultiplier;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        public double Health { get; set ; }

        public double BaseArmor { get; protected set; }

        public double Armor { get ; set ; }

        public double AbilityPoints { get ; set ; }

        public Bag Bag { get; protected set; }

        public Faction Faction { get; set; }

        public bool IsAlive { get; set; }

        public double RestHealMultiplier { get ;protected set ; }

        public void TakeDamage(double hitPoints)
        {
            ValidateLifeStatus();

            this.Armor -= hitPoints;

            if (this.Armor < 0)
            {
                this.Health += this.Armor;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;

                    this.Health = 0;
                }

                this.Armor = 0;
            }
        }

        protected void ValidateLifeStatus()
        {
            if (this.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void Rest()
        {
            ValidateLifeStatus();

            this.Health += this.BaseHealth * this.RestHealMultiplier;

            if (this.Health > this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
        }

        public void UseItem(Item item)
        {
            ValidateLifeStatus();

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            ValidateLifeStatus();
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            ValidateLifeStatus();
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            ValidateLifeStatus();
            this.Bag.AddItem(item);
        }
    }
}
