using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ExtendedDatabase
{
    public class Database
    {
        private List<Person> people;

        public Database()
        {
            this.people = new List<Person>();
        }

        public void Add(Person person)
        {
            if (this.people.Any(x => x.Name == person.Name))
            {
                throw new InvalidOperationException("There is already person with this username in database");
            }

            if (this.people.Any(x => x.Id == person.Id))
            {
                throw new InvalidOperationException("There is already person with this Id in database");
            }

            this.people.Add(person);
        }

        public void Remove(Person person)
        {
            var personToRemove = this.people.FirstOrDefault(x => x.Name == person.Name && x.Id == person.Id);

            if (personToRemove == null)
            {
                throw new ArgumentNullException("There is no such person in database");
            }

            this.people.Remove(personToRemove);
        }

        public Person FindByUsername(string name)
        {
            if (!this.people.Any(x => x.Name == name))
            {
                throw new InvalidOperationException("There is no person with this username in database");
            }
            
            if (name == null)
            {
                throw new ArgumentNullException("Username can not be null");
            }

            var foundPerson = this.people.FirstOrDefault(x => x.Name == name);


            return foundPerson;
        }

        public Person FindById(int id)
        {
            if (!this.people.Any(x => x.Id == id))
            {
                throw new InvalidOperationException("There is no person with this id in database");
            }
            
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Negative id");
            }

            var foundPerson = this.people.FirstOrDefault(x => x.Id == id);

            return foundPerson;
        }
    }
}
