using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Stat
    {
        //        •	Strength: int
        //•	Flexibility: int
        //•	Agility: int
        //•	Skills: int
        //•	Intelligence: int

        private int strength;
        private int flexibility;
        private int agility;
        private int skills;
        private int intelligence;

        public Stat(int strength, int flexibility, int agility, int skills, int intelligence)
        {
            this.Strength = strength;
            this.Flexibility = flexibility;
            this.Agility = agility;
            this.Skills = skills;
            this.Intelligence = intelligence;
        }

        // strength, flexibility, agility, skills and intelligence

        public int Strength
        {
            get { return strength; }
           private set { strength = value; }
        }


        public int Flexibility
        {
            get { return flexibility; }
           private set { flexibility = value; }
        }


        public int Agility
        {
            get { return agility; }
           private set { agility = value; }
        }


        public int Skills
        {
            get { return skills; }
           private set { skills = value; }
        }


        public int Intelligence
        {
            get { return intelligence; }
           private set { intelligence = value; }
        }

    }
}
