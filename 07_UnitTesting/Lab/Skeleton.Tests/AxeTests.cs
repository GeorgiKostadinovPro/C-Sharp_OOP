using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    { 

        [Test]
        public void AxeShouldLooseDurabilityAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(100, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "The durability points of the axe remain the same!");
        }

        [Test]
        public void AttackWithBrokenAxeShouldThrowException()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(10, 0);
                Dummy dummy = new Dummy(100, 10);
                axe.Attack(dummy);

            }, Throws.InvalidOperationException, "Axe is broken.");
        }
    }
}