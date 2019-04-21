namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("SonyEricsson", "T630")]
        public void ConstructorShouldCreateProperPhone(string make, string model)
        {
            var phone = new Phone(make, model);

            Assert.AreEqual(phone.Make, make);
            Assert.AreEqual(phone.Model, model);
        }

        [Test]
        public void MakeCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "T630"));
        }

        [Test]
        public void MakeCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, "T630"));
        }

        [Test]
        public void ModelCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Phone("SonyEricsson", ""));
        }

        [Test]
        public void ModelCannotBeNull()
        {
            Assert.Throws<ArgumentException>(() => new Phone("SonyEricsson", null));
        }

        [Test]
        public void PhonebookShouldStartWithZeroContacts()
        {
            var phone = new Phone("Iphone", "DS69");
            var count = phone.Count;

            Assert.That(count == 0);
        }

        [Test]
        public void PhonebookShouldReturnContactsCount()
        {
            var phone = new Phone("Iphone", "DS69");
            phone.AddContact("Stamat", "088");

            var count = phone.Count;

            Assert.That(count == 1);
        }

        [Test]
        public void PhonebookShouldThrowExceptionForExistingContacts()
        {
            var phone = new Phone("Iphone", "DS69");
            phone.AddContact("Stamat", "088");


            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Stamat", "088"));
        }

        [Test]
        public void PhoneShouldAddContainContactsProperly()
        {
            var phone = new Phone("Iphone", "DS69");
            phone.AddContact("Stamat", "088");
            var kvp = new KeyValuePair<string, string>("Stamat", "088");

            var type = typeof(Phone);

            var fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Static).FirstOrDefault(x => x.Name == "phonebook");

            Assert.That(fieldInfo != null);
        }

        [Test]
        [TestCase ("Stamat")]
        public void CallShouldThrowUnexistingPersonException(string name)
        {
            var phone = new Phone("Iphone", "DS69");

            Assert.Throws<InvalidOperationException>(() => phone.Call(name));
        }

        [Test]
        public void CallShouldReturnCallerInfo()
        {
            var phone = new Phone("Iphone", "DS69");
            phone.AddContact("Stamat", "088");

            var expectedMessage = $"Calling Stamat - 088...";
            var resultMessage = phone.Call("Stamat");

            Assert.AreEqual(expectedMessage, resultMessage);
        }
    }
}