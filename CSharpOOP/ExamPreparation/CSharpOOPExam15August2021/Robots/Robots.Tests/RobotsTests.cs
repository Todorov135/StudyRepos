namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Xml.Linq;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void Test_RobotManagerClassConstructor_Works()
        {
            RobotManager robotManiger = new RobotManager(2);
            Assert.AreEqual(2, robotManiger.Capacity);
        }
        [Test]
        public void Test_RobotManagerClassConstructor_ThrowExceptionWhenInputIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManiger = new RobotManager(-2);

            }, "Invalid capacity!");
        }
        [Test]
        public void Test_AddMethod_Work()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);
            Robot robot2 = new Robot("Eva", 100);
            robotManiger.Add(robot1);
            robotManiger.Add(robot2);

            Assert.AreEqual(2, robotManiger.Count);
        }
        [Test]
        public void Test_AddMethod_ThrowExceptionWhenAddSameRobot()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);

            robotManiger.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManiger.Add(robot1);
            }, "There is already a robot with name WallE!");
        }
        [Test]
        public void Test_AddMethod_ThrowExceptionWhenOutOfCapacity()
        {
            RobotManager robotManiger = new RobotManager(1);
            Robot robot1 = new Robot("WallE", 10);
            Robot robot2 = new Robot("Eva", 100); ;
            robotManiger.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManiger.Add(robot2);
            }, "Not enough capacity!");
        }
        [Test]
        public void Test_RemoveMethod_Work()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);
            Robot robot2 = new Robot("Eva", 100); ;
            robotManiger.Add(robot1);
            robotManiger.Add(robot2);
            robotManiger.Remove("WallE");
            
            Assert.AreEqual(1,robotManiger.Count);
        }
        [Test]
        public void Test_RemoveMethod_ThrowExceptionWhenTryToRemoveIvalidName()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);
            Robot robot2 = new Robot("Eva", 100); ;
            robotManiger.Add(robot1);
            robotManiger.Add(robot2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManiger.Remove("Terminator");
            }, "Robot with the name Terminator doesn't exist!");
        }
        [Test]
        public void Test_WorkMethod_Works()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);
            robotManiger.Add(robot1);

            robotManiger.Work("WallE", "CleanPlanet", 3);
            Assert.AreEqual(7,robot1.Battery);
        }
        [Test]
        public void Test_WorkMethod_ThrowExceptionWhenRobotIsNotInRepository()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);
            robotManiger.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManiger.Work("Terminator", "CleanPlanet", 3);

            }, "Robot with the name Terminator doesn't exist!");
            
        }
        [Test]
        public void Test_WorkMethod_ThrowExceptionWhenRobotIsLowBattery()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);
            robotManiger.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManiger.Work("WallE", "CleanPlanet", 11);

            }, "WallE doesn't have enough battery!");

        }
        [Test]
        public void Test_ChargeMethod_Works()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);
            robotManiger.Add(robot1);
            robotManiger.Work("WallE", "CleanPlanet", 3);
            robotManiger.Charge("WallE");
            Assert.AreEqual(10, robot1.Battery);
        }
        [Test]
        public void Test_ChargeMethod_ThrowExceptionWhenRobotsNameIsInvalid()
        {
            RobotManager robotManiger = new RobotManager(2);
            Robot robot1 = new Robot("WallE", 10);
            robotManiger.Add(robot1);
            robotManiger.Work("WallE", "CleanPlanet", 3);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManiger.Charge("Terminator");

            }, "Robot with the name Terminator doesn't exist!");

        }
    }
}
