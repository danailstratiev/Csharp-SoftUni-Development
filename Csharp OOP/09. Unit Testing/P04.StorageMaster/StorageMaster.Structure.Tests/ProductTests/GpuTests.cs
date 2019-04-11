using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;


namespace StorageMaster.Structure.Tests.ProductTests
{
    public class GpuTests
    {
        private Product gpu;

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void PricePropertyShouldNotBeNegative(double price)
        {
            Assert.Throws<InvalidOperationException>(() => this.gpu = new Gpu(price));
        }

        [Test]
        public void PriceShouldBeSetProperly()
        {
            this.gpu = new Gpu(2.1);

            Assert.That(this.gpu.Price == 2.1);
        }

        [Test]
        public void WeightPropertyShouldReturnProperData()
        {
            this.gpu = new Gpu(2.1);

            Assert.That(this.gpu.Weight == 0.7);
        }
    }
}
