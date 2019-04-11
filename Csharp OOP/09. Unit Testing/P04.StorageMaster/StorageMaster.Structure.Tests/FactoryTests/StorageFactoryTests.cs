using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Factories;
using System;
using System.Reflection;
using System.Linq;

namespace StorageMaster.Structure.Tests.FactoryTests
{
    public class StorageFactoryTests
    {
        private StorageFactory storageFactory;

        [SetUp]
        public void SetUp()
        {
            storageFactory = new StorageFactory();
        }

        [Test]
        [TestCase("Metro", "Billa")]
        public void CreateStorageMethodShouldThrowExceptionIfStorageDoesNotExist(string type, string name)
        {
            Assert.Throws<InvalidOperationException>(() => storageFactory.CreateStorage(type, name));
        }

        [Test]
        [TestCase("Warehouse", "Billa")]
        public void CreateStorageMethodShouldReturnNewStorage(string type, string name)
        {
            var storage = storageFactory.CreateStorage(type, name);

            Warehouse warehouse = storage as Warehouse;

            Assert.That(warehouse is Warehouse);
        }
    }
}
