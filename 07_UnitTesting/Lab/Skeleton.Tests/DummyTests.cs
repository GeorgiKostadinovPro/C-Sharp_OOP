using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {

        [Test]
        public void DummyShouldHealthIfAttacked()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 10);

            //Act
            dummy.TakeAttack(10);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(90), "Dummy doesn't loose health when attacked!");
        }

        [Test]

        public void DeadDummyShouldThrowExceptionIfAttacked()
        {
            Assert.That(() =>
            {
                Dummy dummy = new Dummy(0, 10);
                dummy.TakeAttack(100);

            }, Throws.InvalidOperationException, "Dummy is dead.");
        }

        [Test]

        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);

            int xp = dummy.GiveExperience();

            Assert.That(xp, Is.EqualTo(10));
        }

        [Test]
        public void AliveDummyShouldNotGiveAnyXP()
        {
            Assert.That(() =>
            {
                Dummy dummy = new Dummy(100, 10);
                int xp = dummy.GiveExperience();

            }, Throws.InvalidOperationException, "Target is not dead.");
        }
    }
}