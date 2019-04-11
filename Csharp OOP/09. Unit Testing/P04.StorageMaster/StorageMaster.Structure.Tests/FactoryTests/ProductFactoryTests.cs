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
    public class ProductFactoryTests
    {
        private ProductFactory productFactory;

        [SetUp]
        public void SetUp()
        {
             productFactory = new ProductFactory();
        }

        [Test]
        [TestCase("Keyboard", 2.9)]
        public void CreateProductMethodShouldThrowExceptionIfProductDoesNotExist(string type, double price)
        {
            Assert.Throws<InvalidOperationException>(() => productFactory.CreateProduct(type, price));
        }

        [Test]
        [TestCase("Ram", 1.9)]
        public void CreateProductMethodShouldReturnNewProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);

            var productRam = product as Ram;

            Assert.That(productRam.GetType().Name == "Ram");
        }
    }
}
