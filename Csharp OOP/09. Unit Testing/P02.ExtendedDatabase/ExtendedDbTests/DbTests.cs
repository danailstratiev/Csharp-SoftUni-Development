using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private Database db;

        [SetUp]
        public void Setup()
        {
            this.db = new Database();
        }

        [Test]
        public void ConstructorShouldSetDbProperly()
        {
            var type = typeof(Database);

            var peopleInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).
                FirstOrDefault(x => x.Name == "people");

            var peopleCollection = (IList<Person>)peopleInfo.GetValue(this.db);

            Assert.That(peopleCollection.Count == 0);
        }

        [Test]
        public void AddMethodShouldThrowExceptionOnExistingUsername()
        {
            var person = new Person("starBoy", 69);

            this.db.Add(person);

            Assert.Throws<InvalidOperationException>(() => this.db.Add(person));
        }

        [Test]
        public void AddMethodShouldThrowExceptionOnExistingId()
        {
            var person = new Person("starBoy", 69);

            this.db.Add(person);

            Assert.Throws<InvalidOperationException>(() => this.db.Add(person));
        }

        [Test]
        public void AddMethodShouldAddNewPeople()
        {
            var person = new Person("starBoy", 69);

            this.db.Add(person);

            var type = typeof(Database);

            var peopleInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).
                FirstOrDefault(x => x.Name == "people");

            var peopleCollection = (IList<Person>)peopleInfo.GetValue(this.db);

            Assert.That(peopleCollection[peopleCollection.Count - 1].Equals(person));
        }

        [Test]
        public void RemoveShouldThrowInvalidPersonException()
        {
            var person = new Person("starBoy", 69);

            Assert.Throws<ArgumentNullException>(() => db.Remove(person));
        }

        [Test]
        public void RemoveShouldRemovePeopleFromDatabase()
        {
            var person = new Person("starBoy", 69);

            this.db.Add(person);
            this.db.Add(new Person("Stam", 57));

            db.Remove(person);

            var type = typeof(Database);

            var peopleInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).
                FirstOrDefault(x => x.Name == "people");

            var peopleCollection = (IList<Person>)peopleInfo.GetValue(this.db);

            Assert.That(peopleCollection.Count == 1);
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenPersonIsNotOnDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => this.db.FindByUsername("Stamat"));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionWhenUsernameIsNull()
        {
            this.db.Add(new Person(null, 159));
            Assert.Throws<ArgumentNullException>(() => this.db.FindByUsername(null));
        }

        [Test]
        public void FindByUsernameShouldFindPeopleByUsername()
        {
            var person = new Person("starBoy", 69);

            this.db.Add(person);
            this.db.Add(new Person("Stam", 57));

            var foundPerson = db.FindByUsername("starBoy");

            Assert.AreEqual(foundPerson, person);
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenPersonIdIsNotOnDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => this.db.FindById(753));
        }

        [Test]
        public void FindByIdShouldThrowExceptionWhenPersonIdIsNegative()
        {
            this.db.Add(new Person("Stam", -57));

            Assert.Throws<ArgumentOutOfRangeException>(() => this.db.FindById(-57));
        }

        [Test]
        public void FindByIdnameShouldFindPeopleById()
        {
            var person = new Person("starBoy", 69);

            this.db.Add(person);
            this.db.Add(new Person("Stam", 57));

            var foundPerson = db.FindById(69);

            Assert.AreEqual(foundPerson, person);
        }

    }
}