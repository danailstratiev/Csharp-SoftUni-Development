using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;

namespace StorageMaster.Structure.Tests.ProductTests
{
    public class SolidStateDriveTests
    {
        private Product solidStateDrive;

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void PricePropertyShouldNotBeNegative(double price)
        {
            Assert.Throws<InvalidOperationException>(() => this.solidStateDrive = new SolidStateDrive(price));
        }

        [Test]
        public void PriceShouldBeSetProperly()
        {
            this.solidStateDrive = new SolidStateDrive(1.7);

            Assert.That(this.solidStateDrive.Price == 1.7);
        }

        [Test]
        public void WeightPropertyShouldReturnProperData()
        {
            this.solidStateDrive = new SolidStateDrive(1.7);

            Assert.That(this.solidStateDrive.Weight == 0.2);
        }
    }
}
