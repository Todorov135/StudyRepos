using NUnit.Framework;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_DummyLossingHealthAfterBeingAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(1);
            Assert.That(dummy.Health, Is.EqualTo(9), "Dummy don`t loose health after being attckced!");
        }
        [Test]
        public void Test_ThrowExceptionIfDeadDummyIsAttacked()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(2);
            }, "Dummy is dead.");
        }
        [Test]
        public void Test_DummyGivingExperienceAfterDead()
        {
            int expectedExperience = 10;
            Dummy dummy = new Dummy(1, expectedExperience);
            dummy.TakeAttack(1);
            int actualExperience = dummy.GiveExperience();

            Assert.AreEqual(expectedExperience, actualExperience, "Dummy don`t get experience after dead!");
        }
        [Test]
        public void Test_DummyDonotGiveExperienceAfterStayAlive()
        {
            int expectedExperience = 10;

            Dummy dummy = new Dummy(10, expectedExperience);
           

            dummy.TakeAttack(1);
            Type dummyType = dummy.GetType();
            
            FieldInfo experienceField = dummyType
                .GetFields(BindingFlags.Instance|BindingFlags.Static|BindingFlags.NonPublic)
                .FirstOrDefault(f=>f.Name == "experience");
            int actualExpierence =(int)experienceField?.GetValue(dummy);
            Assert.AreEqual(expectedExperience, actualExpierence);
        }


        [Test]
        public void Test_MethodIsDeadReturnProperStatment()
        {
            bool expectedStatment = false;
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(1);
            bool actualStatment = dummy.IsDead();
            Assert.AreEqual(expectedStatment, actualStatment);
        }
    }
}