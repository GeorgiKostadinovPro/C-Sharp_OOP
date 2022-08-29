namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {

        [Test]

        public void ConstructorShouldWorkProperly()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void MakeGetterShouldWorkProperly()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            string make = car.Make;

            Assert.AreEqual(car.Make, make);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakeSetterShouldThrowExceptionWhenNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "SLS", 5, 100));
        }

        [Test]
        public void ModelGetterShouldWorkProperly()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            string model = car.Model;

            Assert.AreEqual(car.Model, model);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelSetterShouldThrowExceptionWhenNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", model, 5, 100));
        }

        [Test]
        public void FuelConsumptionGetterShouldWorkProperly()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            double consumption = car.FuelConsumption;

            Assert.AreEqual(car.FuelConsumption, consumption);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionSetterShouldThrowExceptionWhenNullOrEmpty(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "SLS", fuelConsumption, 100));
        }


        [Test]
        public void FuelCapacityGetterShouldWorkProperly()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            double consumption = car.FuelCapacity;

            Assert.AreEqual(car.FuelCapacity, consumption);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacitySetterShouldThrowExceptionWhenNullOrEmpty(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", "SLS", 5, fuelCapacity));
        }


        [Test]

        public void RefuelMethodShouldWorkProperly()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            car.Refuel(100);

            Assert.AreEqual(100, car.FuelAmount);
        }

        [Test]

        public void RefuelMethodShouldSetFuelAmountToFuelCapacityWhenExceedingTheCapacity()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            car.Refuel(150);

            Assert.AreEqual(100, car.FuelAmount);
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethodShouldThrowExceptionWhenTheRefuelingFuelIsEqualOrLessThanZero(double fuelToRefuel)
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        public void DriveMethodShouldWorkProperly()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            car.Refuel(100);
            car.Drive(10);

            Assert.AreEqual(99.5, car.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionWhen()
        {
            Car car = new Car("Mecedes", "SLS", 5, 100);

            car.Refuel(100);

            Assert.Throws<InvalidOperationException>(() => car.Drive(10000));
        }
    }
}