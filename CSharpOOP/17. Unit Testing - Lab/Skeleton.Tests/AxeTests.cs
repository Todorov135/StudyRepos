using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {

        [Test]
        public void Test_AxeClassGettersAreFilledProperly()
        {
            int axeAttack = 10;
            int axeDurability = 10;

            Axe axe = new Axe(axeAttack, axeDurability);

            int expectedAxeAttack = axe.AttackPoints;
            int expectedAxeDurability = axe.DurabilityPoints;

            Assert.AreEqual(expectedAxeAttack, axeAttack, "Axe attack points should be equal!");
            Assert.AreEqual(expectedAxeDurability, axeDurability, "Axe durability points should be equal!");
            
        }

        [Test]
        public void Test_AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn`t change after attack.");
        }
        [Test]
        public void Test_AttackWithBrokenWeapon()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);
           
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
               
            }, "Axe is broken.");
             
        }
    }
}