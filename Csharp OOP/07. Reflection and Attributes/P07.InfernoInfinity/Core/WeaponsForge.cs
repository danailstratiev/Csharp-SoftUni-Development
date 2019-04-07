using P07.InfernoInfinity.Armory;
using P07.InfernoInfinity.Armory.RarityLevel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P07.InfernoInfinity.Core
{
    public class WeaponsForge
    {
        public Weapon ForgeAWeapon(string weaponType, Rarity rarityLevel, string weaponName)
        {
            switch (weaponType)
            {
                case "Axe":
                    return new Axe(weaponName, rarityLevel);
                case "Sword":
                    return new Sword(weaponName, rarityLevel);
                case "Knife":
                    return new Knife(weaponName, rarityLevel);
                default:
                    return null;
            }
        }
    }
}
