using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Storage;
using System;
using System.Reflection;
using System.Linq;

namespace StorageMaster.Structure.Tests.StorageTests
{
    public class DistributionCenterTests
    {
        private Storage distributionCenter;

        [SetUp]
        public void SetUp()
        {
            this.distributionCenter = new DistributionCenter("DHLdistrubutions");
        }
        [Test]
        public void NamePropertyShouldReturnProperData()
        {
            Assert.That(this.distributionCenter.Name == "DHLdistrubutions");
        }

        [Test]
        public void CapacityPropertyShouldReturnProperData()
        {
            Assert.That(this.distributionCenter.Capacity == 2);
        }

        [Test]
        public void GarageSlotsPropertyShouldReturnProperData()
        {
            Assert.That(this.distributionCenter.GarageSlots == 5);
        }

        [Test]
        public void GarageShouldStartWithThreeSemiVehicles()
        {
            var counter = 0;
            foreach (var vehicle in this.distributionCenter.Garage)
            {
                if (vehicle is Van)
                {
                    counter++;
                }
            }

            Assert.That(counter == 3);
        }

        [Test]
        public void DistributionCenterStartsWithZeroProducts()
        {
            Assert.That(this.distributionCenter.Products.Count == 0);
        }

        [Test]
        [TestCase(10)]
        [TestCase(15)]
        public void GetVehicleShouldThrowExceptionOnInvalidIndex(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => this.distributionCenter.GetVehicle(garageSlot));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        public void GetVehicleShouldThrowExceptionWhenThereIsNoVehicleOnGarageSlot(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => this.distributionCenter.GetVehicle(garageSlot));
        }

        [Test]
        [TestCase(2)]
        public void GetVehicleShouldGiveVehicleFromGarageSlot(int garageSlot)
        {
            Assert.That(this.distributionCenter.GetVehicle(garageSlot) != null);
        }

        [Test]
        public void SendVehicleToShouldThrowExeptionOnFullStorage()
        {
            int garageSlot = 1;
            var vehicle = this.distributionCenter.GetVehicle(0);
            var deliveryLocation = new AutomatedWarehouse("Baumax");
            distributionCenter.SendVehicleTo(garageSlot, deliveryLocation);

            Assert.Throws<InvalidOperationException>(() => distributionCenter.SendVehicleTo(garageSlot, deliveryLocation));
        }

        [Test]
        public void SendVehicleToShouldReturnProperAddedSlot()
        {
            int garageSlot = 1;
            var vehicle = this.distributionCenter.GetVehicle(0);
            var deliveryLocation = new AutomatedWarehouse("Baumax");
            var addedSlot = distributionCenter.SendVehicleTo(garageSlot, deliveryLocation);

            Assert.That(addedSlot == garageSlot);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            Assert.That(distributionCenter.IsFull == false);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            var vehicle = distributionCenter.GetVehicle(1);
            for (int i = 0; i < 2; i++)
            {
                vehicle.LoadProduct(new HardDrive(2.5));
                this.distributionCenter.UnloadVehicle(1);
            }
            Assert.IsTrue(distributionCenter.IsFull);
        }

        [Test]
        public void UnloadVehicleShouldThrowExceptionIfStorageIsFull()
        {
            var vehicle = distributionCenter.GetVehicle(1);
            for (int i = 0; i < 2; i++)
            {
                vehicle.LoadProduct(new HardDrive(2.5));
                this.distributionCenter.UnloadVehicle(1);
            }

            vehicle.LoadProduct(new HardDrive(2.5));

            Assert.Throws<InvalidOperationException>(() => this.distributionCenter.UnloadVehicle(1));
        }

        [Test]
        public void UnloadVehicleShouldReturnCountOfUnloadedProducts()
        {
            var vehicle = distributionCenter.GetVehicle(1);
            vehicle.LoadProduct(new Ram(2.6));
            vehicle.LoadProduct(new Ram(2.6));

            var counter = this.distributionCenter.UnloadVehicle(1);

            Assert.That(counter == 2);
        }
    }
}
