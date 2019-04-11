using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace StorageMaster.Structure.Tests.VehicleTests
{
    public class SemiTests
    {
        private Vehicle semi;

        [SetUp]
        public void Setup()
        {
            this.semi = new Semi();
        }

        [Test]
        public void LoadProductMethodShouldAddNewProduct()
        {
            Product product = new Ram(2.57);

            this.semi.LoadProduct(product);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.semi.Trunk.Count);
        }

        [Test]
        public void LoadProductMethodShouldThrowExceptionWhenCapacityIsFull()
        {
            Product product = new HardDrive(2.57);

            for (int i = 0; i < 10; i++)
            {
                this.semi.LoadProduct(product);
            }

            Assert.Throws<InvalidOperationException>(() => semi.LoadProduct(product));
        }

        [Test]
        public void UnloadMethodShouldThrowExceptionWhenCapacityIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => semi.Unload());
        }

        [Test]
        public void UnloadProductMethodShouldRemoveProduct()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 5; i++)
            {
                this.semi.LoadProduct(product);
            }

            Product lastProduct = new HardDrive(3.60);

            this.semi.LoadProduct(lastProduct);

            Product expectedProduct = this.semi.Unload();

            int expectedCount = 5;

            Assert.AreEqual(expectedCount, this.semi.Trunk.Count);
            Assert.AreEqual(expectedProduct, lastProduct);
        }

        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.semi.IsEmpty;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmptyReturnsFalse()
        {
            Product product = new HardDrive(3.60);

            this.semi.LoadProduct(product);

            var result = this.semi.IsEmpty;

            Assert.IsFalse(result);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            Product product = new HardDrive(3.60);

            for (int i = 0; i < 10; i++)
            {
                this.semi.LoadProduct(product);

            }

            var result = this.semi.IsFull;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            var result = this.semi.IsFull;

            Assert.IsFalse(result);
        }

        [Test]
        public void CapacityIsSetProperly()
        {
            Assert.That(10 == this.semi.Capacity);
        }

        [Test]
        public void PropertyTrunkReturnsCorrectData()
        {
            Assert.AreEqual(0, this.semi.Trunk.Count);
        }
    }
}
