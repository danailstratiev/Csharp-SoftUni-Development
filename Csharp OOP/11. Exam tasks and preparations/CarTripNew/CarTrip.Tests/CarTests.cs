using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase("FordFocus", 70.5, 69, 0.5)]
        public void ConstructorShouldProperlyCreateCar(string model, double tankCapacity,
           double tank, double fuelConsumptionPerKm)
        {
            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);

            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(tankCapacity, car.TankCapacity);
            Assert.AreEqual(tank, car.FuelAmount);
            Assert.AreEqual(fuelConsumptionPerKm, car.FuelConsumptionPerKm);
        }

        [Test]
        [TestCase("", 70.5, 69, 0.5)]
        [TestCase(null, 70.5, 69, 0.5)]
        public void ModelCanNotBeNullOrWhiteSpace(string model, double tankCapacity,
            double tank, double fuelConsumptionPerKm)
        {
            Assert.Throws<ArgumentException>(() => new Car(model, tankCapacity, tank, fuelConsumptionPerKm));
        }

        [Test]
        public void ModelCanNotBeEmptyNullOrWhiteSpace()
        {
            var model = string.Empty;

            Assert.Throws<ArgumentException>(() => new Car(model, 70.5, 69, 0.5));
        }

        [Test]
        public void ModelShouldReturnProperValue()
        {
            var car = new Car("FordFocus", 70.5, 69, 0.5);

            Assert.AreEqual("FordFocus", car.Model);
        }
        [Test]
        public void TankCapacityShouldReturnProperValue()
        {
            var car = new Car("FordFocus", 70.5, 69, 0.5);

            Assert.AreEqual(70.5, car.TankCapacity);
        }



        [Test]
        [TestCase("Moskvich", 60.5, 69, 0.5)]
        public void FuelAmountCanNotBeBiggerThanTankCapacity(string model, double tankCapacity,
            double tank, double fuelConsumptionPerKm)
        {
            Assert.Throws<ArgumentException>(() => new Car(model, tankCapacity, tank, fuelConsumptionPerKm));
        }

        [Test]
        [TestCase("Moskvich", 60.5, 69, -0.5)]
        [TestCase("Moskvich", 60.5, 69, 0)]
        public void FuelConsumptionCanNotBeNegativeOrZero(string model, double tankCapacity,
            double tank, double fuelConsumptionPerKm)
        {
            Assert.Throws<ArgumentException>(() => new Car(model, tankCapacity, tank, fuelConsumptionPerKm));
        }

        [Test]
        [TestCase(1000)]
        public void DriveShouldThrowInvalidOperationExceptionWhenFuelAmountIsLessThanTripConsumption(double distance)
        {
            var car = new Car("FordFocus", 70.5, 69, 0.5);
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        [TestCase(100)]
        public void DriveShouldProperlyDecreaseFuelAmount(double distance)
        {
            var car = new Car("FordFocus", 70.5, 69, 0.5);
            var expectedFuelAmount = car.FuelAmount - (distance * car.FuelConsumptionPerKm);

            car.Drive(distance);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(100)]
        public void DriveShouldReturnHaveANiceTripMessage(double distance)
        {
            var car = new Car("FordFocus", 70.5, 69, 0.5);

            var expectedMessage = "Have a nice trip";
            var resultMessage = car.Drive(distance);

            Assert.AreEqual(expectedMessage, resultMessage);
        }

        [Test]
        [TestCase(10)]
        public void RefuelShouldThrowInvalidOperationExceptionWhenTankCannotTakeFuelAmount(double fuelAmount)
        {
            var car = new Car("FordFocus", 70.5, 69, 0.5);

            Assert.Throws<InvalidOperationException>(() => car.Refuel(fuelAmount));
        }

        [Test]
        [TestCase(10)]
        public void RefuelMethodShouldSuccessfullyIncreaseCarFuelAmount(double fuelAmount)
        {
            var car = new Car("FordFocus", 80.5, 69, 0.5);

            var expectedValue = 79;

            car.Refuel(fuelAmount);
            Assert.AreEqual(expectedValue, car.FuelAmount);
        }
    }
}
