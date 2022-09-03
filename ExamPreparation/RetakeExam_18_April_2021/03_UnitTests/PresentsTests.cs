namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {

        [Test]
        public void CheckIfPresentIsCreatedProperly()
        {
            Present p = new Present("iPhone", 10);
            Assert.AreEqual("iPhone", p.Name);
        }

        [Test]
        public void TestBagCreateMethodWorkingProperly()
        {
            Present p = new Present("iPhone", 10);

            Bag bag = new Bag();
            bag.Create(p);

            Assert.AreEqual(1, bag.GetPresents().Count);
        }


        [Test]
        public void TestBagCreateMethodThrowingNullException()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void TestBagCreateMethodThrowingInvalidOperationException()
        {
            Present p = new Present("iPhone", 10);

            Bag bag = new Bag();
            bag.Create(p);

            Assert.Throws<InvalidOperationException>(() => bag.Create(p));
        }

        [Test]
        public void TestRemoveMethodWorkingProperly()
        {
            Present p = new Present("iPhone", 10);

            Bag bag = new Bag();
            bag.Create(p);

            Assert.AreEqual(true, bag.Remove(p));
        }

        [Test]
        public void TestBagGetPresentWithLestMagicWorkingProperly()
        {
            Present p1 = new Present("iPhone", 10);
            Present p2 = new Present("Samsung", 15);
            Present p3 = new Present("Nokia", 5);

            Bag bag = new Bag();
            bag.Create(p1);
            bag.Create(p2);
            bag.Create(p3);

            Assert.AreEqual(p3, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void TestBagGetPresentWorkingProperly()
        {
            Present p1 = new Present("iPhone", 10);
            Present p2 = new Present("Samsung", 15);
            Present p3 = new Present("Nokia", 5);

            Bag bag = new Bag();
            bag.Create(p1);
            bag.Create(p2);
            bag.Create(p3);

            Assert.AreEqual(p3, bag.GetPresent("Nokia"));
        }
    }
}
