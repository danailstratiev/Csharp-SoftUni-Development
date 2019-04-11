using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Storage;
using System;
using System.Reflection;
using System.Linq;

namespace StorageMaster.Structure.Tests.StorageTests
{
    public class WarehouseTests
    {
        private Storage warehouse;

        [SetUp]
        public void SetUp()
        {
            this.warehouse = new Warehouse("MasterHouse");
        }
        [Test]
        public void NamePropertyShouldReturnProperData()
        {
            Assert.That(this.warehouse.Name == "MasterHouse");
        }

        [Test]
        public void CapacityPropertyShouldReturnProperData()
        {
            Assert.That(this.warehouse.Capacity == 10);
        }

        [Test]
        public void GarageSlotsPropertyShouldReturnProperData()
        {
            Assert.That(this.warehouse.GarageSlots == 10);
        }

        [Test]
        public void GarageShouldStartWithThreeSemiVehicles()
        {
            var counter = 0;
            foreach (var vehicle in this.warehouse.Garage)
            {
                if (vehicle is Semi)
                {
                    counter++;
                }
            }

            Assert.That(counter == 3);
        }

        [Test]
        public void WarehouseStartsWithZeroProducts()
        {
            Assert.That(this.warehouse.Products.Count == 0);
        }

        [Test]
        [TestCase(10)]
        [TestCase(15)]
        public void GetVehicleShouldThrowExceptionOnInvalidIndex(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(garageSlot));
        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        public void GetVehicleShouldThrowExceptionWhenThereIsNoVehicleOnGarageSlot(int garageSlot)
        {
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(garageSlot));
        }

        [Test]
        [TestCase(2)]
        public void GetVehicleShouldGiveVehicleFromGarageSlot(int garageSlot)
        {
            Assert.That(this.warehouse.GetVehicle(garageSlot) != null);
        }

        [Test]
        public void SendVehicleToShouldThrowExeptionOnFullStorage()
        {
            int garageSlot = 1;
            var vehicle = this.warehouse.GetVehicle(0);
            var deliveryLocation = new AutomatedWarehouse("Baumax");
            warehouse.SendVehicleTo(garageSlot, deliveryLocation);

            Assert.Throws<InvalidOperationException>(() => warehouse.SendVehicleTo(garageSlot, deliveryLocation));
        }

        [Test]
        public void SendVehicleToShouldReturnProperAddedSlot()
        {
            int garageSlot = 1;
            var vehicle = this.warehouse.GetVehicle(0);
            var deliveryLocation = new AutomatedWarehouse("Baumax");
            var addedSlot = warehouse.SendVehicleTo(garageSlot, deliveryLocation);

            Assert.That(addedSlot == garageSlot);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            Assert.That(warehouse.IsFull == false);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            var vehicle = warehouse.GetVehicle(1);
            for (int i = 0; i < 10; i++)
            {
                vehicle.LoadProduct(new HardDrive(2.5));
                this.warehouse.UnloadVehicle(1);
            }
            Assert.IsTrue(warehouse.IsFull);
        }

        [Test]
        public void UnloadVehicleShouldThrowExceptionIfStorageIsFull()
        {
            var vehicle = warehouse.GetVehicle(1);
            for (int i = 0; i < 10; i++)
            {
                vehicle.LoadProduct(new HardDrive(2.5));
                this.warehouse.UnloadVehicle(1);
            }

            vehicle.LoadProduct(new HardDrive(2.5));

            Assert.Throws<InvalidOperationException>(() => this.warehouse.UnloadVehicle(1));
        }

        [Test]
        public void UnloadVehicleShouldReturnCountOfUnloadedProducts()
        {
            var vehicle = warehouse.GetVehicle(1);
            vehicle.LoadProduct(new Ram(2.6));
            vehicle.LoadProduct(new Ram(2.6));
            vehicle.LoadProduct(new Ram(2.6));

            var counter = this.warehouse.UnloadVehicle(1);

            Assert.That(counter == 3);
        }
    }
}
