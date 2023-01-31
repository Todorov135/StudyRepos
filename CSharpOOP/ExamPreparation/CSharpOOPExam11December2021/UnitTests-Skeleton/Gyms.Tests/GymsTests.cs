namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class GymsTests
    {
        [Test]
        public void Test_Setter_Work()
        {
            Gym gym = new Gym("PowerRangers", 10);
            Assert.AreEqual("PowerRangers", gym.Name);
            Assert.AreEqual(10, gym.Capacity);
        }
        [Test]
        public void Test_NameSetterWithNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
            Gym gym = new Gym(null, 10);
            }, "Invalid gym name.");
        }
        [Test]
        public void Test_NameSetterWithEmptyString_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 10);
            }, "Invalid gym name.");
        }
        [Test]
        public void Test_CapacitySetterWithInvalidValue_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("PowerRangers", -1);
            }, "Invalid gym capacity.");
        }
        [Test]
        public void Test_AddAthleteMethod_Work()
        {
            Gym gym = new Gym("PowerRangers", 10);
            Athlete pinkPowerRanger = new Athlete("Pinki");
            gym.AddAthlete(pinkPowerRanger);
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void Test_AddAthleteMethodWhenAddMoreThenCapacity_ShouldThrowException()
        {
            Gym gym = new Gym("PowerRangers", 1);
            Athlete pinkPowerRanger = new Athlete("Pinki");
            Athlete yellowPowerRanger = new Athlete("Brain");
            gym.AddAthlete(pinkPowerRanger);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(yellowPowerRanger);
            }, "The gym is full.");
        }
        [Test]
        public void Test_RemoveAthlete_Work()
        {
            Gym gym = new Gym("PowerRangers", 2);
            Athlete pinkPowerRanger = new Athlete("Pinki");
            Athlete yellowPowerRanger = new Athlete("Brain");
            gym.AddAthlete(pinkPowerRanger);
            gym.AddAthlete(yellowPowerRanger);
            Assert.AreEqual(2, gym.Count);

            gym.RemoveAthlete("Brain");
            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void Test_RemoveAthleteWhitInwalidName_ShouldThrowException()
        {
            Gym gym = new Gym("PowerRangers", 2);
            Athlete pinkPowerRanger = new Athlete("Pinki");
            Athlete yellowPowerRanger = new Athlete("Brain");
            gym.AddAthlete(pinkPowerRanger);
            gym.AddAthlete(yellowPowerRanger);            

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Porky");
            }, $"The athlete Porky doesn't exist.");
        }
        [Test]
        public void Test_InjureAthlete_Work()
        {
            Gym gym = new Gym("PowerRangers", 2);
            Athlete pinkPowerRanger = new Athlete("Pinki");
            Athlete yellowPowerRanger = new Athlete("Brain");
            gym.AddAthlete(pinkPowerRanger);
            gym.AddAthlete(yellowPowerRanger);

            Athlete actual = gym.InjureAthlete("Brain");
            Assert.AreEqual(yellowPowerRanger, actual);
            Assert.AreEqual(true, yellowPowerRanger.IsInjured);
        }
        [Test]
        public void Test_InjureAthleteWhitInwalidName_ShouldThrowException()
        {
            Gym gym = new Gym("PowerRangers", 2);
            Athlete pinkPowerRanger = new Athlete("Pinki");
            Athlete yellowPowerRanger = new Athlete("Brain");
            gym.AddAthlete(pinkPowerRanger);
            gym.AddAthlete(yellowPowerRanger);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Porky");
            }, $"The athlete Porky doesn't exist.");
        }
        [Test]
        public void Test_Report_Work()
        {
            Gym gym = new Gym("PowerRangers", 2);
            Athlete pinkPowerRanger = new Athlete("Pinki");
            Athlete yellowPowerRanger = new Athlete("Brain");
            gym.AddAthlete(pinkPowerRanger);
            gym.AddAthlete(yellowPowerRanger);
                       
            string expected = "Active athletes at PowerRangers: Pinki, Brain";
            string actual = gym.Report();
            Assert.AreEqual(expected, actual);
        }
    }
}
