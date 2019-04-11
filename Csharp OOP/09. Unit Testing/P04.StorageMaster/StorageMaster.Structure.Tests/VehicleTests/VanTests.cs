using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace Tests
{
    public class VanTests
    {
        private Vehicle van;

        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void LoadProductMethodShouldAddNewProduct()
        {
            Product product = new Ram(2.57);

            this.van.LoadProduct(product);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.van.Trunk.Count);
        }

        [Test]
        public void LoadProductMethodShouldThrowExceptionWhenCapacityIsFull()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }
            
            Assert.Throws<InvalidOperationException>(() => van.LoadProduct(product));
        }

        [Test]
        public void UnloadMethodShouldThrowExceptionWhenCapacityIsEmpty()
        {            
            Assert.Throws<InvalidOperationException>(() => van.Unload());
        }

        [Test]
        public void UnloadProductMethodShouldRemoveProduct()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 5; i++)
            {
                this.van.LoadProduct(product);
            }

            Product lastProduct = new HardDrive(3.60);

            this.van.LoadProduct(lastProduct);

            Product expectedProduct = this.van.Unload();

            int expectedCount = 5;

            Assert.AreEqual(expectedCount, this.van.Trunk.Count);
            Assert.AreEqual(expectedProduct ,lastProduct);
        }

        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.van.IsEmpty;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmptyReturnsFalse()
        {
            Product product = new HardDrive(3.60);

            this.van.LoadProduct(product);

            var result = this.van.IsEmpty;

            Assert.IsFalse(result);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            Product product = new HardDrive(3.60);

            this.van.LoadProduct(product);
            this.van.LoadProduct(product);

            var result = this.van.IsFull;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            var result = this.van.IsFull;

            Assert.IsFalse(result);
        }

        [Test]
        public void CapacityIsSetProperly()
        {
            Assert.That(2 == this.van.Capacity);
        }

        [Test]
        public void PropertyTrunkReturnsCorrectData()
        {            
            Assert.AreEqual(0, this.van.Trunk.Count);
        }
    }
}