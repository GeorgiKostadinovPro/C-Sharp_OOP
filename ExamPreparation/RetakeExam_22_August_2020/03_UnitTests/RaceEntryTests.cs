using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverMethodWorkingProperly()
        {
            UnitCar car = new UnitCar("Tesla", 500, 5000);
            UnitDriver driver = new UnitDriver("Go4ko", car);

            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            Assert.AreEqual(1, race.Counter);
        }


        [Test]
        public void AddDriverMethodThrowingInvalidDriverNullException()
        {
            RaceEntry race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }


        [Test]
        public void AddDriverMethodThrowingExistingDriverException()
        {
            UnitCar car = new UnitCar("Tesla", 500, 5000);
            UnitDriver driver = new UnitDriver("Go4ko", car);

            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void CalculateAverageHorsePowerWorkingProperly()
        {
            UnitCar car = new UnitCar("Tesla", 500, 5000);
            UnitDriver driver = new UnitDriver("Go4ko", car);

            UnitCar car1 = new UnitCar("BMW", 600, 6600);
            UnitDriver driver1 = new UnitDriver("Dani", car1);

            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);
            race.AddDriver(driver1);

            Assert.AreEqual(550, race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerThrowingException()
        {
            UnitCar car = new UnitCar("Tesla", 500, 5000);
            UnitDriver driver = new UnitDriver("Go4ko", car);

            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }
    }
}