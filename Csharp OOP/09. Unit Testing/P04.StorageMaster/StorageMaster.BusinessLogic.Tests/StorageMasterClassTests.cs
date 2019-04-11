using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Storage;
using StorageMaster.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using StorageMaster.Entities.Factories;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMasterClassTests
    {
        private StorageMaster storageMaster;

        [SetUp]
        public void Setup()
        {
            this.storageMaster = new StorageMaster();
        }

        [Test]
        public void AddProductShouldAddProduct()
        {
            var productsToBeAdded = new List<Product>() { new Ram(1.9), new Gpu(2.3) };

            foreach (var product in productsToBeAdded)
            {
                this.storageMaster.AddProduct(product.GetType().Name, product.Price);
            }

            var typeSM = typeof(StorageMaster);

            var smProductPoolInfo = typeSM.GetFields(BindingFlags.NonPublic | BindingFlags.Static
                | BindingFlags.Instance).FirstOrDefault(x => x.Name == "productsPool");

            var smProductPool = smProductPoolInfo.GetValue(storageMaster);

            var countInfo = smProductPool.GetType().GetProperty("Count");

            var countOfAddedProducts = (int)(countInfo.GetValue(smProductPool, null));

            Assert.That(countOfAddedProducts == productsToBeAdded.Count);
        }

        [Test]
        [TestCase("Ram", 1.9)]
        public void AddProductShoulReturnMessage(string type, double price)
        {
            var returnMessage = this.storageMaster.AddProduct(type, price);
            var expectedMessage = $"Added {type} to pool";

            Assert.That(returnMessage == expectedMessage);
        }

        [Test]
        [TestCase("Warehouse", "Masterhouse")]
        public void RegisterStorageShouldAddStorage(string type, string name)
        {
            this.storageMaster.RegisterStorage(type, name);

            var typeSM = typeof(StorageMaster);

            var smStorageRegistryInfo = typeSM.GetFields(BindingFlags.NonPublic | BindingFlags.Static
                | BindingFlags.Instance).FirstOrDefault(x => x.Name == "storageRegistry");

            var smStorageRegistry = smStorageRegistryInfo.GetValue(storageMaster);

            var countInfo = smStorageRegistry.GetType().GetProperty("Count");

            var countOfRegisteredStorages = (int)(countInfo.GetValue(smStorageRegistry, null));

            Assert.That(countOfRegisteredStorages == 1);
        }

        [Test]
        [TestCase("Warehouse", "Masterhouse")]
        public void RegisterStorageReturnMessage(string type, string name)
        {
            var storage = new StorageFactory().CreateStorage(type, name);
            var registrationMessage = this.storageMaster.RegisterStorage(type, name);
            var expectedMessage = $"Registered {storage.Name}";

            Assert.AreEqual(expectedMessage, registrationMessage);
        }

        [Test]
        [TestCase("Masterhouse", 0)]
        public void SelectVehicleMethodShouldSetCurrentVehicle(string storageName, int garageSlot)
        {

            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");
            storageMaster.SelectVehicle(storageName, garageSlot);

            var typeSM = typeof(StorageMaster);

            var smCurrentVehicleInfo = typeSM.GetFields(BindingFlags.NonPublic | BindingFlags.Static
                | BindingFlags.Instance).FirstOrDefault(x => x.Name == "currentVehicle");

            var expectedVehicle = smCurrentVehicleInfo.GetValue(storageMaster);

            var semi = (Semi)expectedVehicle;

            Assert.That(semi is Semi);
        }

        [Test]
        [TestCase("Masterhouse", 0)]
        public void SelectVehicleMethodShouldReturnMessage(string storageName, int garageSlot)
        {

            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");
            var resultMessage = storageMaster.SelectVehicle(storageName, garageSlot);

            var typeSM = typeof(StorageMaster);

            var smCurrentVehicleInfo = typeSM.GetFields(BindingFlags.NonPublic | BindingFlags.Static
                | BindingFlags.Instance).FirstOrDefault(x => x.Name == "currentVehicle");

            var expectedVehicle = smCurrentVehicleInfo.GetValue(storageMaster);

            var semi = (Semi)expectedVehicle;

            var expectedMessage = $"Selected {semi.GetType().Name}";

            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [Test]
        public void LoadVehicleMethodShouldThrowOutOfStockException()
        {
            IEnumerable<string> productNames = new List<string>() { "Keyboard", "Mouse" };
            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");
            storageMaster.SelectVehicle("Masterhouse", 0);
            Assert.Throws<InvalidOperationException>(() => this.storageMaster.LoadVehicle(productNames));
        }

        [Test]
        public void LoadVehicleMethodShouldRetturnMessage()
        {
            var productsToBeAdded = new List<Product>() { new Ram(1.9), new Gpu(2.3) };

            foreach (var product in productsToBeAdded)
            {
                this.storageMaster.AddProduct(product.GetType().Name, product.Price);
            }
            IEnumerable<string> productNames = new List<string>() { "Ram", "Gpu" };
            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");
            storageMaster.SelectVehicle("Masterhouse", 0);

            var typeSM = typeof(StorageMaster);

            var smCurrentVehicleInfo = typeSM.GetFields(BindingFlags.NonPublic | BindingFlags.Static
                | BindingFlags.Instance).FirstOrDefault(x => x.Name == "currentVehicle");

            var expectedVehicle = smCurrentVehicleInfo.GetValue(storageMaster);

            var semi = (Semi)expectedVehicle;

            var expectedMessage = $"Loaded {2}/{productNames.Count()} products into {semi.GetType().Name}";

            var resultMessage = this.storageMaster.LoadVehicle(productNames);

            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [Test]
        [TestCase("Masterhouse", 0, "Baumax")]
        public void SendVehicleToShouldThrowInvalidSourceStorageException
            (string sourceName, int sourceGarageSlot, string destinationName)
        {
            Assert.Throws<InvalidOperationException>(() => this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
        }

        [Test]
        [TestCase("Masterhouse", 0, "Baumax")]
        public void SendVehicleToShouldThrowInvalidDestinationStorageException
            (string sourceName, int sourceGarageSlot, string destinationName)
        {
            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");

            Assert.Throws<InvalidOperationException>(() => this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
        }

        [Test]
        [TestCase("Masterhouse", 0, "Baumax")]
        public void SendVehicleToShouldReturnSuccessfullyCompletionMessage
            (string sourceName, int sourceGarageSlot, string destinationName)
        {
            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");
            this.storageMaster.RegisterStorage("AutomatedWarehouse", "Baumax");

            var expectedVehicle = new Semi();

            var expectedMessage = $"Sent {expectedVehicle.GetType().Name} to {new AutomatedWarehouse("Baumax").Name} (slot {sourceGarageSlot + 1})";
            var resultMessage = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);

            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [Test]
        [TestCase("Masterhouse", 0)]
        public void UnloadVehicleShouldReturnSuccessfullyCompletionMessage(string storageName, int garageSlot)
        {
            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");

            var expectedMessage = $"Unloaded 2/2 products at {storageName}";

            var resultMessage = this.storageMaster.UnloadVehicle(storageName, garageSlot);

            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [Test]
        [TestCase("Masterhouse")]
        public void GetStorageStatusShouldReturnProperMessage(string storageName)
        {
            var storage = new Warehouse(storageName);

            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsCapacity,
                storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            var expectedMessage = stockFormat + Environment.NewLine + garageFormat;

            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");
            var resultMessage = this.storageMaster.GetStorageStatus(storageName);

            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [Test]
        public void GetSummaryMethodShouldReturnProperInformation()
        {
            var storage = new Warehouse("Masterhouse");

            this.storageMaster.RegisterStorage("Warehouse", "Masterhouse");

            var sb = new StringBuilder();
            sb.AppendLine($"{storage.Name}:");
            var totalMoney = storage.Products.Sum(p => p.Price);
            sb.AppendLine($"Storage worth: ${totalMoney:F2}");

            var expectedMessage = sb.ToString().TrimEnd('\r', '\n');

            var resultMessage = this.storageMaster.GetSummary();

            Assert.AreEqual(expectedMessage, resultMessage);
        }
    }
}