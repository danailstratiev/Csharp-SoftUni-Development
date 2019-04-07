using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using P07.InfernoInfinity.Gems;
using P07.InfernoInfinity.Armory.RarityLevel;

namespace P07.InfernoInfinity.Armory
{
    public abstract class Weapon : IFindable, IPowerful
    {
        protected Weapon(string name, int minDamage, int maxDamage, Rarity levelOfRarity)
        {
            this.Name = name;
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
            this.Sockets = new List<Gem>();
            this.LevelOfRarity = levelOfRarity;
            this.Strength = 0;
            this.Agility = 0;
            this.Vitality = 0;
        }

        public string Name { get; private set; }

        public int MinDamage { get; private set; }

        public int MaxDamage { get; private set; }

        public List<Gem> Sockets { get; private set; }

        public Rarity LevelOfRarity { get; private set; }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }

        public abstract void Add(Gem gem, int index);

        public void Remove(int index)
        {
            this.Sockets.RemoveAt(index);
        }

        public void CalculateWeaponRarity()
        {
            this.MinDamage *= this.LevelOfRarity.DamageMultiplier;
            this.MaxDamage *= this.LevelOfRarity.DamageMultiplier;
        }

        public void CalculateWeaponTotalPower()
        {
            foreach (var gem in this.Sockets)
            {
                this.Strength += gem.Strength;
                this.Agility += gem.Agility;
                this.Vitality += gem.Vitality;
            }
        }

        public void CalculateFinalWeaponDamage()
        {
            this.MinDamage += this.Strength * 2;
            this.MinDamage += this.Agility * 1;
            this.MaxDamage += this.Strength * 3;
            this.MaxDamage += this.Agility * 4;
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
        }
    }
}
