using System;
using System.Collections.Generic;
using System.Text;

namespace P06.BirthdayCelebrations
{
    public class Pet : LivingCreature
    {
        public Pet(string name, string birthdate) 
            : base(name, birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
    }
}
