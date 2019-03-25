using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P06.BirthdayCelebrations
{
    public abstract class LivingCreature : IBirthdable
    {
        protected LivingCreature(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; protected set; }

        public string Birthdate { get; protected set; }
    }
}
