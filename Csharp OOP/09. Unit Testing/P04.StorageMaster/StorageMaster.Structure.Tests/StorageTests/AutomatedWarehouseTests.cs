using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Storage;
using System;

namespace StorageMaster.Structure.Tests.StorageTests
{
    public class AutomatedWarehouseTests
    {
        private Storage automatedWarehouse;

        [SetUp]
        public void SetUp()
        {
            this.automatedWarehouse = new AutomatedWarehouse("Baumax");
        }
        [Test]
        public void NamePropertyShouldReturnProperData()
        {
            Assert.That(this.automatedWarehouse.Name == "Baumax");
        }

        [Test]
        public void CapacityPropertyShouldReturnProperData()
        {
            Assert.That(this.automatedWarehouse.Capacity == 1);
        }

        [Test]
        public void GarageSlotsPropertyShouldReturnProperData()
        {
            Assert.That(this.automatedWarehouse.GarageSlots == 2);
        }

        [Test]
        public void GarageShouldStartWithOneTruckVehicle()
        {
            var counter = 0;
            foreach (var vehicle in this.automatedWarehouse.Garage)
            {
                if (vehicle is Truck)
                {
                    counter++;
                }
            }

            Assert.That(counter == 1);
        }

        [Test]
        public void WarehouseStartsWithZeroProducts()
        {
            Assert.That(this.automatedWarehouse.Products.Count == 0);
        }

        [Test]
        [TestCase(10)]
        [TestCase(15)]
        public void GetVehicleShouldThrowExceptionOnInvalidIndex(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.GetVehicle(garageSlot));
        }

        [Test]
        [TestCase(2)]
        public void GetVehicleShouldThrowExceptionWhenThereIsNoVehicleOnGarageSlot(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.GetVehicle(garageSlot));
        }

        [Test]
        [TestCase(0)]
        public void GetVehicleShouldGiveVehicleFromGarageSlot(int garageSlot)
        {
            Assert.That(this.automatedWarehouse.GetVehicle(garageSlot) != null);
        }

        [Test]
        public void SendVehicleToShouldThrowExeptionOnFullStorage()
        {
            int garageSlot = 0;
            var vehicle = this.automatedWarehouse.GetVehicle(0);
            var deliveryLocation = new AutomatedWarehouse("MrBricoulage");
            automatedWarehouse.SendVehicleTo(garageSlot, deliveryLocation);

            Assert.Throws<InvalidOperationException>(() => automatedWarehouse.SendVehicleTo(garageSlot, deliveryLocation));
        }

        [Test]
        public void SendVehicleToShouldReturnProperAddedSlot()
        {
            int garageSlot = 0;
            var vehicle = this.automatedWarehouse.GetVehicle(0);
            var deliveryLocation = new AutomatedWarehouse("MrBricoulage");
            var addedSlot = automatedWarehouse.SendVehicleTo(garageSlot, deliveryLocation);

            Assert.That(addedSlot == 1);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            Assert.That(automatedWarehouse.IsFull == false);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            var vehicle = automatedWarehouse.GetVehicle(0);
            for (int i = 0; i < 11; i++)
            {
                vehicle.LoadProduct(new Ram(1.5));
                this.automatedWarehouse.UnloadVehicle(0);
            }
            Assert.IsTrue(automatedWarehouse.IsFull);
        }

        [Test]
        public void UnloadVehicleShouldThrowExceptionIfStorageIsFull()
        {
            var vehicle = automatedWarehouse.GetVehicle(0);
            for (int i = 0; i < 5; i++)
            {
                vehicle.LoadProduct(new SolidStateDrive(1.5));
                this.automatedWarehouse.UnloadVehicle(0);
            }

            vehicle.LoadProduct(new SolidStateDrive(1.5));

            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.UnloadVehicle(0));
        }

        [Test]
        public void UnloadVehicleShouldReturnCountOfUnloadedProducts()
        {
            var vehicle = automatedWarehouse.GetVehicle(0);
            vehicle.LoadProduct(new Ram(2.6));
            vehicle.LoadProduct(new Ram(2.6));

            var counter = this.automatedWarehouse.UnloadVehicle(0);

            Assert.That(counter == 2);
        }
    }
}
