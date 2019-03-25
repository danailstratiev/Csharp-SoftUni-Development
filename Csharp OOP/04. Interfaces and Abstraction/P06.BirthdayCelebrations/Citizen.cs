using System;
using System.Collections.Generic;
using System.Text;

namespace P06.BirthdayCelebrations
{
    public class Citizen : LivingCreature
    {
        public Citizen(string name,int age, string id, string birthdate) 
            : base(name, birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public int Age { get; private set; }

        public string Id { get;private set; }
    }
}
