using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        //        •	Name: string
        //•	Stat: Stat
        //•	Weapon: Weapon
        //•	GetTotalPower() : int – return the sum of the stat properties plus the sum of the weapon properties.
        //•	GetWeaponPower() : int - return the sum of the weapon properties.
        // •	GetStatPower(): int - return the sum of the stat properties.


        private string name;
        private Stat stat;
        private Weapon weapon;

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }


        public Stat Stat
        {
            get { return this.stat; }
            private set { this.stat = value; }
        }


        public Weapon Weapon
        {
            get { return this.weapon; }
            private set { this.weapon = value; }
        }


        //•	GetTotalPower() : int – return the sum of the stat properties plus the sum of the weapon properties.

        public int GetTotalPower()
        {
            var getTotalPower = 0;

            getTotalPower = this.GetStatPower() + this.GetWeaponPower();

            return getTotalPower;
        }

        //•	GetWeaponPower() : int - return the sum of the weapon properties.

        public int GetWeaponPower()
        {
            var getWeaponPower = 0;

            getWeaponPower += this.Weapon.Sharpness;
            getWeaponPower += this.Weapon.Size;
            getWeaponPower += this.Weapon.Solidity;

            return getWeaponPower;
        }

        // •	GetStatPower(): int - return the sum of the stat properties.

        public int GetStatPower()
        {
            var getStatPower = 0;

            getStatPower += this.Stat.Agility;
            getStatPower += this.Stat.Flexibility;
            getStatPower += this.Stat.Intelligence;
            getStatPower += this.Stat.Skills;
            getStatPower += this.Stat.Strength;

            return getStatPower;
        }

        //The class constructor should receive name, stat and weapon and override ToString() in the following format:
        //"[Gladiator name] - [Gladiator total power]"
        //"  Weapon Power: [Gladiator weapon power]"
        //"  Stat Power: [Gladiator stat power]"

        // TO DO - Check For Braces
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{this.GetStatPower()}]");

            return sb.ToString().TrimEnd();
        }
    }
}
