using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using P07.InfernoInfinity.Armory.RarityLevel;
using P07.InfernoInfinity.Gems;

namespace P07.InfernoInfinity.Armory
{
    public class Axe : Weapon
    {
        private const int minDamage = 5;
        private const int maxDamage = 10;

        public Axe(string name, Rarity levelOfRarity)
            : base(name, minDamage, maxDamage, levelOfRarity)
        {
        }

        public override void Add(Gem gem, int index)
        {
            if (index < 4 && index >= 0)
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
