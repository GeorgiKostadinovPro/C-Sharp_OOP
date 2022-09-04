namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void RobotConstructorShouldWorkProperly()
        {
            Robot robot = new Robot("George", 100);

            Assert.AreEqual("George", robot.Name);
            Assert.AreEqual(100, robot.Battery);
            Assert.AreEqual(100, robot.MaximumBattery);
        }

        [Test]
        public void RobotManagerConstructorShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(10);

            Assert.AreEqual(robotManager.Capacity, 10);
        }

        [Test]
        public void RobotManagerCountShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(10);

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManagerCapacityShouldThrowExceptionWhenUnderZero()
        {
            Assert.That(() =>
            {
               RobotManager robotManager = new RobotManager(-1);
            }, Throws.ArgumentException.With.Message.EqualTo("Invalid capacity!"));
        }

        [Test]
        public void RobotManagerAddMethodShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("George", 100);

            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RobotManagerShouldThrowExceptionWhenRobotExists()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("George", 100);
            Robot robot2 = new Robot("George", 100);

            robotManager.Add(robot1);

            Assert.That(() => { 
               robotManager.Add(robot2);
            }, Throws.InvalidOperationException.With.Message.EqualTo("There is already a robot with name George!"));
        }

        [Test]
        public void RobotManagerAddMethodShouldThrowExceptionWhenThereIsNoSpace()
        {
            RobotManager robotManager = new RobotManager(2);

            Robot robot1 = new Robot("George", 100);
            Robot robot2 = new Robot("Lyubo", 100);
            robotManager.Add(robot1);
            robotManager.Add(robot2);


            Assert.That(() =>
            {
                robotManager.Add(new Robot("Kris", 100));
            }, Throws.InvalidOperationException.With.Message.EqualTo("Not enough capacity!"));
        }

        [Test]
        public void RobotManagerRemoveMethodShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("George", 100);

            robotManager.Add(robot);
            robotManager.Remove("George");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManagerRemoveMethodShouldThrowExceptionWhenNoRobotIsFound()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("George", 100);

            robotManager.Add(robot);

            Assert.That(() => {
                robotManager.Remove("Lyubo");
            }, Throws.InvalidOperationException.With.Message.EqualTo("Robot with the name Lyubo doesn't exist!"));
        }

        [Test]
        public void RobotManagerWorkMethodShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("George", 100);

            robotManager.Add(robot);
            robotManager.Work("George", "CTO", 10);

            Assert.AreEqual(robot.Battery, 90);
        }

        [Test]
        public void RobotManagerWorkMethodShouldThrowExceptionWhenNoRobotIsFound()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("George", 100);

            robotManager.Add(robot);

            Assert.That(() => { 
                robotManager.Work("Lyubo", "CTO", 10);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Robot with the name Lyubo doesn't exist!"));
           
        }

        [Test]
        public void RobotManagerWorkMethodShouldThrowExceptionWhenTheRobotDoesntHaveEnoughBattery()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("George", 5);

            robotManager.Add(robot);

            Assert.That(() => {
                robotManager.Work("George", "CTO", 10);
            }, Throws.InvalidOperationException.With.Message.EqualTo("George doesn't have enough battery!"));

        }

        [Test]
        public void RobotManagerChargeMethodShouldWorkProperly()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("George", 100);

            robotManager.Add(robot);
            robotManager.Work("George", "CTO", 10);
            robotManager.Charge("George");

            Assert.AreEqual(robot.Battery, 100);
        }

        [Test]
        public void RobotManagerChargeMethodShouldThrowExceptionWhenNoRobotIsFound()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot = new Robot("George", 100);

            robotManager.Add(robot);

            Assert.That(() => {
                robotManager.Charge("Lyubo");
            }, Throws.InvalidOperationException.With.Message.EqualTo("Robot with the name Lyubo doesn't exist!"));

        }
    }
}
