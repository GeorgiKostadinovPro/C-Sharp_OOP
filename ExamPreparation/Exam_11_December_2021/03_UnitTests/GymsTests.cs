using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void TestConstructorWorkingProperly()
        {
            Gym gym = new Gym("Greg", 2);

            Assert.AreEqual("Greg", gym.Name);
        }

        [Test]
        public void TestConstructorWorkingProperlyWithSize()
        {
            Gym gym = new Gym("Greg", 2);

            Assert.AreEqual(2, gym.Capacity);
        }

        [Test]
        public void TestNameThrowingException()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 2));
        }

        [Test]
        public void TestCapacityThrowingException()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Greg", -2));
        }

        [Test]
        public void TestAddAthleteMethodWorkingProperly()
        {
            Athlete a = new Athlete("Marto");
            Athlete a1 = new Athlete("Go4ko");

            Gym gym = new Gym("Greg", 3);
            gym.AddAthlete(a);
            gym.AddAthlete(a1);

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void TestAddAthleteMethodThrowingException()
        {
            Athlete a = new Athlete("Marto");
            Athlete a1 = new Athlete("Go4ko");

            Gym gym = new Gym("Greg", 2);
            gym.AddAthlete(a);
            gym.AddAthlete(a1);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Niki")));
        }

        [Test]
        public void TestRemoveAthleteMethodWorkingProperly()
        {
            Athlete a = new Athlete("Marto");
            Athlete a1 = new Athlete("Go4ko");

            Gym gym = new Gym("Greg", 3);
            gym.AddAthlete(a);
            gym.AddAthlete(a1);

            gym.RemoveAthlete(a.FullName);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void TestRemoveAthleteMethodThrowingException()
        {
            Athlete a = new Athlete("Marto");
            Athlete a1 = new Athlete("Go4ko");

            Gym gym = new Gym("Greg", 2);
            gym.AddAthlete(a);
            gym.AddAthlete(a1);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Niki"));
        }

        [Test]
        public void TestInjureAthleteWorkingProperly()
        {
            Athlete a = new Athlete("Marto");
            Athlete a1 = new Athlete("Go4ko");

            Gym gym = new Gym("Greg", 3);
            gym.AddAthlete(a);
            gym.AddAthlete(a1);

            var requested = gym.InjureAthlete(a.FullName);

            Assert.AreEqual(a.FullName, requested.FullName);
        }

        [Test]
        public void TestInjureAthleteThrowingException()
        {
            Athlete a = new Athlete("Marto");
            Athlete a1 = new Athlete("Go4ko");

            Gym gym = new Gym("Greg", 3);
            gym.AddAthlete(a);
            gym.AddAthlete(a1);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Niki"));
        }

        [Test]
        public void TestReportMethod()
        {
            Athlete a = new Athlete("Marto");
            Athlete a1 = new Athlete("Go4ko");

            Gym gym = new Gym("Greg", 3);

            gym.AddAthlete(a);
            gym.AddAthlete(a1);

            string expectedResult = "Active athletes at Greg: Marto, Go4ko";
            Assert.AreEqual(expectedResult, gym.Report());
        }
    }
}
