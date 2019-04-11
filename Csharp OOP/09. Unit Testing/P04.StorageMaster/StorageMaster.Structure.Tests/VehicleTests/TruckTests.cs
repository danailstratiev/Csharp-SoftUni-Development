using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace StorageMaster.Structure.Tests.VehicleTests
{
    public class TruckTests
    {
        private Truck truck;

        [SetUp]
        public void Setup()
        {
            this.truck = new Truck();
        }

        [Test]
        public void LoadProductMethodShouldAddNewProduct()
        {
            Product product = new Ram(2.57);

            this.truck.LoadProduct(product);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.truck.Trunk.Count);
        }

        [Test]
        public void LoadProductMethodShouldThrowExceptionWhenCapacityIsFull()
        {
            Product product = new HardDrive(2.57);

            for (int i = 0; i < 5; i++)
            {
                this.truck.LoadProduct(product);
            }

            Assert.Throws<InvalidOperationException>(() => truck.LoadProduct(product));
        }

        [Test]
        public void UnloadMethodShouldThrowExceptionWhenCapacityIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => truck.Unload());
        }

        [Test]
        public void UnloadProductMethodShouldRemoveProduct()
        {
            Product product = new Ram(2.57);

            for (int i = 0; i < 5; i++)
            {
                this.truck.LoadProduct(product);
            }

            Product lastProduct = new HardDrive(3.60);

            this.truck.LoadProduct(lastProduct);

            Product expectedProduct = this.truck.Unload();

            int expectedCount = 5;

            Assert.AreEqual(expectedCount, this.truck.Trunk.Count);
            Assert.AreEqual(expectedProduct, lastProduct);
        }

        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.truck.IsEmpty;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmptyReturnsFalse()
        {
            Product product = new HardDrive(3.60);

            this.truck.LoadProduct(product);

            var result = this.truck.IsEmpty;

            Assert.IsFalse(result);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            Product product = new HardDrive(3.60);

            this.truck.LoadProduct(product);
            this.truck.LoadProduct(product);
            this.truck.LoadProduct(product);
            this.truck.LoadProduct(product);
            this.truck.LoadProduct(product);

            var result = this.truck.IsFull;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            var result = this.truck.IsFull;

            Assert.IsFalse(result);
        }

        [Test]
        public void CapacityIsSetProperly()
        {
            Assert.That(5 == this.truck.Capacity);
        }

        [Test]
        public void PropertyTrunkReturnsCorrectData()
        {
            Assert.AreEqual(0, this.truck.Trunk.Count);
        }

    }
}
