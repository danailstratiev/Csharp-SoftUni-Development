using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace ExtendedDbTests
{
    public class PersonTests
    {
        private Person person;

        [Test]
        [TestCase("Stamat", 57)]
        public void ConstructorShouldSetProperPersonData(string name, int id)
        {
            person = new Person(name, id);

            Assert.AreEqual(person.Name, "Stamat");
            Assert.AreEqual(person.Id, 57);
        }
    }
}
