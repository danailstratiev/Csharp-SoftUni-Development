using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using P07.InfernoInfinity.Armory.RarityLevel;
using P07.InfernoInfinity.Gems;

namespace P07.InfernoInfinity.Armory
{
    public class Knife : Weapon
    {
        private const int minDamage = 3;
        private const int maxDamage = 4;

        public Knife(string name, Rarity levelOfRarity) 
            : base(name, minDamage, maxDamage, levelOfRarity)
        {
        }

        public override void Add(Gem gem, int index)
        {
            if (index < 2 && index >= 0)
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
