using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Family
    {
        private List<Person> family = new List<Person>();

        public void AddMember(Person member)
        {
            this.family.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.family.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }
}
