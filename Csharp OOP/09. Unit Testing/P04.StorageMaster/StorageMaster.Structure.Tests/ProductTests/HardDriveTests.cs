using NUnit.Framework;
using StorageMaster.Entities.Products;
using System;

namespace StorageMaster.Structure.Tests.ProductTests
{
    public class HardDriveTests
    {
        private Product hardDrive;
                
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void PricePropertyShouldNotBeNegative(double price)
        {
            Assert.Throws<InvalidOperationException>(() => this.hardDrive = new HardDrive(price));
        }

        [Test]
        public void PriceShouldBeSetProperly()
        {
            this.hardDrive = new HardDrive(2.6);

            Assert.That(this.hardDrive.Price == 2.6);
        }

        [Test]
        public void WeightPropertyShouldReturnProperData()
        {
            this.hardDrive = new HardDrive(2.6);

            Assert.That(this.hardDrive.Weight == 1);
        }
    }
}
