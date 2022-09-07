using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
           [Test]
            public void TestConstructorForMechanicsAvailable()
            {
                Garage garage = new Garage("Mercedes-Benz", 15);

                Assert.AreEqual(15, garage.MechanicsAvailable);
            }

            [Test]
            public void TestMechanicsAvailableArgumentException()
            {
                Assert.Throws<ArgumentException>(() => new Garage("Mercedes-Benz", -10));
            }

            [Test]
            public void TestConstructorForName()
            {
                Garage garage = new Garage("Mercedes-Benz", 15);

                Assert.AreEqual("Mercedes-Benz", garage.Name);
            }

            [Test]
            public void TestNameArgumentException()
            {
                Assert.Throws<ArgumentNullException>(() => new Garage("", 10));
            }

            [Test]
            public void TestAddCarMethodWorkingProperly()
            {
                Garage garage = new Garage("Mercedes-Benz", 15);

                Car car = new Car("Bentley", 10);
                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void TestAddMethodThrowingException()
            {
                Garage garage = new Garage("Mercedes-Benz", 2);

                Car car = new Car("Bentley", 10);
                Car car1 = new Car("Audi", 5);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(new Car("BMW", 2)));
            }

            [Test]
            public void TestFixCarMethodWorkingProperly()
            {
                Garage garage = new Garage("Mercedes-Benz", 2);

                Car car = new Car("Bentley", 10);
                Car car1 = new Car("Audi", 5);
                garage.AddCar(car);
                garage.AddCar(car1);

                Car carToFix = garage.FixCar("Bentley");

                Assert.AreEqual(0, carToFix.NumberOfIssues);
            }

            [Test]
            public void TestFixCarMethodThrowingException()
            {
                Garage garage = new Garage("Mercedes-Benz", 2);

                Car car = new Car("Bentley", 10);
                Car car1 = new Car("Audi", 5);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() => garage.FixCar("BMW"));
            }

            [Test]
            public void RemoveFixedCarMethodWorkingProperly()
            {
                Garage garage = new Garage("Mercedes-Benz", 2);

                Car car = new Car("Bentley", 10);
                Car car1 = new Car("Audi", 5);
                garage.AddCar(car);
                garage.AddCar(car1);

                garage.FixCar("Bentley");
                garage.RemoveFixedCar();

                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void TestRemoveFixedCarMethodThrowingException()
            {
                Garage garage = new Garage("Mercedes-Benz", 2);

                Car car = new Car("Bentley", 10);
                Car car1 = new Car("Audi", 5);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }
            
            [Test]
            public void ReportMethodWorkingProperly()
            {
                Garage garage = new Garage("Mercedes-Benz", 2);

                Car car = new Car("Bentley", 10);
                Car car1 = new Car("Audi", 5);
                garage.AddCar(car);
                garage.AddCar(car1);

                string output = garage.Report();
                string expectedOutput = "There are 2 which are not fixed: Bentley, Audi.";

                Assert.AreEqual(expectedOutput, output);
            }
        }
    }
}