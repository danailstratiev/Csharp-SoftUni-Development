using P07.InfernoInfinity.Armory.RarityLevel;
using P07.InfernoInfinity.Gems;
using System;

namespace P07.InfernoInfinity.Armory
{
    public class Sword : Weapon
    {
        private const int minDamage = 4;
        private const int maxDamage = 6;

        public Sword(string name, Rarity levelOfRarity) 
            : base(name, minDamage, maxDamage, levelOfRarity)
        {
        }

        public override void Add(Gem gem, int index)
        {
            if (index < 3 && index >= 0)
            {
                gem.ClarifyWeapon();

                try
                {
                    this.Sockets[index] = gem;

                }
                catch (Exception)
                {
                    this.Sockets.Insert(index, gem);
                }
            }
        }
    }
}
