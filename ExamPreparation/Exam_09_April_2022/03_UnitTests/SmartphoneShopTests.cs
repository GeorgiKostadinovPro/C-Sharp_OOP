using NUnit.Framework;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void ShopConstrcutorShouldWorkProperly()
        {
            Shop shop = new Shop(10);

            Assert.AreEqual(10, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void ShopCapacityShouldThrowExceptionWhenValueIsUnderZero()
        {
            Assert.That(() =>
            {
                Shop shop = new Shop(-1);
            }, Throws.ArgumentException.With.Message.EqualTo("Invalid capacity."));
        }

        [Test]
        public void AddMethodShouldWorkProperly()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 100);

            shop.Add(smartphone);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenPhoneAlreadyExists()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 100);

            shop.Add(smartphone);


            Assert.That(() =>
            {
                shop.Add(smartphone);
            }, Throws.InvalidOperationException.With.Message.EqualTo("The phone model Samsung S10 already exist."));
        }


        [Test]
        public void AddMethodShouldThrowExceptionWhenCapacityIsFull()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Samsung S10", 100);
            Smartphone smartphone2 = new Smartphone("Samsung S9", 100);


            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.That(() =>
            {
                shop.Add(new Smartphone("IPhone XS", 100));
            }, Throws.InvalidOperationException.With.Message.EqualTo("The shop is full."));
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 100);

            shop.Add(smartphone);
            shop.Remove("Samsung S10");

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenPhoneDoesNotExist()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 100);

            shop.Add(smartphone);

            Assert.That(() =>
            {
                shop.Remove("Samsung S9");
            }, Throws.InvalidOperationException.With.Message.EqualTo("The phone model Samsung S9 doesn't exist."));
        }

        [Test]
        public void TestPhoneMethodShouldWorkProperly()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 100);

            shop.Add(smartphone);
            shop.TestPhone("Samsung S10", 50);

            Assert.AreEqual(50, smartphone.CurrentBateryCharge);
        }


        [Test]
        public void TestPhoneMethodShouldThrowExceptionWhenPhoneDoesNotExist()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 100);

            shop.Add(smartphone);

            Assert.That(() =>
            {
                shop.TestPhone("Samsung S9", 50);
            }, Throws.InvalidOperationException.With.Message.EqualTo("The phone model Samsung S9 doesn't exist."));
        }

        [Test]
        public void TestPhoneMethodShouldThrowExceptionWhenPhoneIsLowOnBattery()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 50);

            shop.Add(smartphone);

            Assert.That(() =>
            {
                shop.TestPhone("Samsung S10", 100);
            }, Throws.InvalidOperationException.With.Message.EqualTo("The phone model Samsung S10 is low on batery."));
        }

        [Test]
        public void ChargePhoneMethodShouldWorkProperly()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 100);

            shop.Add(smartphone);
            shop.TestPhone("Samsung S10", 80);
            shop.ChargePhone("Samsung S10");

            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void ChargePhoneMethodShouldThrowExceptionWhenPhoneDoesNotExist()
        {
            Shop shop = new Shop(10);
            Smartphone smartphone = new Smartphone("Samsung S10", 100);

            shop.Add(smartphone);
            shop.TestPhone("Samsung S10", 80);
            

            Assert.That(() =>
            {
                shop.ChargePhone("Samsung S9");
            }, Throws.InvalidOperationException.With.Message.EqualTo("The phone model Samsung S9 doesn't exist."));
        }
    }
}