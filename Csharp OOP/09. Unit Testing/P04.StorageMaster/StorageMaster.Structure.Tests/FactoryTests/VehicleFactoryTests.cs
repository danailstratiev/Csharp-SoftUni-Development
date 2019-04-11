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
    public class VehicleFactoryTests
    {
        private VehicleFactory vehicleFactory;

        [SetUp]
        public void SetUp()
        {
            vehicleFactory = new VehicleFactory();
        }

        [Test]
        [TestCase("ZAS")]
        public void CreateVehicleMethodShouldThrowExceptionIfVehicleDoesNotExist(string type)
        {
            Assert.Throws<InvalidOperationException>(() => vehicleFactory.CreateVehicle(type));
        }

        [Test]
        [TestCase("Truck")]
        public void CreateVehicleMethodShouldReturnNewVehicle(string type)
        {
            var vehicle = vehicleFactory.CreateVehicle(type);

            Truck truck = vehicle as Truck;

            Assert.That(truck is Truck);
        }
    }
}
