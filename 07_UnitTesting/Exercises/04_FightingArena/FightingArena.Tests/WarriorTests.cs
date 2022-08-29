namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Warrior warrior = new Warrior("George", 100, 100);

            Assert.AreEqual(("George", 100, 100), (warrior.Name, warrior.Damage, warrior.HP));
        }

        [Test]
        public void NameGetterShouldWorkProperly()
        {
            Warrior warrior = new Warrior("George", 100, 100);

            string name = warrior.Name;

            Assert.AreEqual("George", name);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]

        public void NameSetterShouldThrowExceptionWhenIsNullEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 100, 100));
        }

        [Test]
        public void DamageGetterShouldWorkProperly()
        {
            Warrior warrior = new Warrior("George", 100, 100);

            int damage = warrior.Damage;

            Assert.AreEqual(100,  damage);
        }

        [TestCase(0)]
        [TestCase(-1)]

        public void DamageSetterShouldThrowExceptionWhenIsLessOrEqualToZero(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("George", damage, 100));
        }

        [Test]
        public void HPGetterShouldWorkProperly()
        {
            Warrior warrior = new Warrior("George", 100, 100);

            int hp = warrior.HP;

            Assert.AreEqual(100, hp);
        }

        [Test]

        public void HPSetterShouldThrowExceptionWhenIsLessthanZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("George", 100, -1));
        }


        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void AttackMethodShouldThrowExceptionWhenHPIsLessThanOrEqualMinAttackHP(int hp)
        {
            Warrior warrior = new Warrior("George", 100, hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Lyubo", 100, 100)));
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        public void AttackMethodShouldThrowExceptionWhenWarriorHPIsLessThanOrEqualMinAttackHP(int hp)
        {
            Warrior warrior = new Warrior("George", 100, 100);

            Assert.That(() =>
            {

                warrior.Attack(new Warrior("Lyubo", 100, hp));

            }, Throws.InvalidOperationException.With.Message.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionWhenHPIsLessThanWarriorHP()
        {
            Warrior warrior = new Warrior("George", 100, 100);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Lyubo", 200, 100)));
        }


        [Test]
        public void AttackMethodShouldWorkProperly()
        {
            Warrior firstWarrior = new Warrior("George", 100, 100);
            Warrior secondWarrior = new Warrior("Lyubo", 50, 100);

            firstWarrior.Attack(secondWarrior);

            Assert.AreEqual(50, firstWarrior.HP);
        }

        [Test]
        public void AttackMethodShloudLowerWarriorHPByFirstWarriorDamage()
        {
            Warrior firstWarrior = new Warrior("George", 100, 100);
            Warrior secondWarrior = new Warrior("Lyubo", 50, 100);

            firstWarrior.Attack(secondWarrior);

            Assert.AreEqual(0, secondWarrior.HP);
        }

        [Test]
        public void AttackMethodShouldWorkProperlyAndShouldSetWarriorHPToZero()
        {
            Warrior firstWarrior = new Warrior("George", 100, 100);
            Warrior secondWarrior = new Warrior("Lyubo", 50, 50);

            firstWarrior.Attack(secondWarrior);

            Assert.AreEqual(0, secondWarrior.HP);
        }
    }
}