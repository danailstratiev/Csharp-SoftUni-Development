using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;

namespace StorageMaster.Structure.Tests.ProductTests
{
    public class RamTests
    {
        private Product ram;

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void PricePropertyShouldNotBeNegative(double price)
        {
            Assert.Throws<InvalidOperationException>(() => this.ram = new Ram(price));
        }

        [Test]
        public void PriceShouldBeSetProperly()
        {
            this.ram = new Ram(1.6);

            Assert.That(this.ram.Price == 1.6);
        }

        [Test]
        public void WeightPropertyShouldReturnProperData()
        {
            this.ram = new Ram(1.6);

            Assert.That(this.ram.Weight == 0.1);
        }
    }
}
