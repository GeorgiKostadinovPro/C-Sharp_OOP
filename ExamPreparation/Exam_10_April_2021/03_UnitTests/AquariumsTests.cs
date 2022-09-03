namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void TestFishClassWorkingProperly()
        {
            Fish fish = new Fish("Nemo");
            Assert.AreEqual(true, fish.Available);
        }

        [Test]
        public void TestAquariumClassConstructor()
        {
            Aquarium aquarium = new Aquarium("Go4ko", 10);
            Assert.AreEqual(10, aquarium.Capacity);
        }

        [Test]
        public void TestAquariumNamePropertythrowingException()
        {
            Assert.Throws<ArgumentNullException>(() =>  new Aquarium("", 10));
        }

        [Test]
        public void TestAquariumCapacityPropertythrowingException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Go4ko", -1));
        }

        [Test]
        public void TestAquariumAddMethodWorkingProperly()
        {
            Aquarium aquarium = new Aquarium("Go4ko", 10);
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);

            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void TestAquariumAddMethodThrowingException()
        {
            Aquarium aquarium = new Aquarium("Go4ko", 1);
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Doroti")));
        }

        [Test]
        public void TestAquariumRemoveMethodWorkingProperly()
        {
            Aquarium aquarium = new Aquarium("Go4ko", 10);
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);
            aquarium.RemoveFish("Nemo");

            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void TestAquariumRemoveMethodthrowingException()
        {
            Aquarium aquarium = new Aquarium("Go4ko", 10);
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Gustavo"));
        }

        [Test]
        public void TestAquariumSellFishMethodWorkingProperly()
        {
            Aquarium aquarium = new Aquarium("Go4ko", 10);
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);

            Fish requestedFish = aquarium.SellFish("Nemo");

            Assert.AreEqual(false, requestedFish.Available);
        }


        [Test]
        public void TestAquariumSellFishMethodthrowingException()
        {
            Aquarium aquarium = new Aquarium("Go4ko", 10);
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Gustavo"));
        }

        [Test]
        public void TestReportMethodWorkingProperly()
        {
            Aquarium aquarium = new Aquarium("Go4ko", 10);
            Fish fish = new Fish("Nemo");

            aquarium.Add(fish);
            string result = aquarium.Report();

            Assert.AreEqual($"Fish available at Go4ko: Nemo", result);
        }
    }
}
