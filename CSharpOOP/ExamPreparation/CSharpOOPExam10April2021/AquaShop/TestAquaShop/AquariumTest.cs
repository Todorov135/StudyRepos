using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace TestAquaShop
{
    [TestFixture]        
    internal class AquariumTest
    {
        [Test]
        public void AquaruimCounter()
        {
            List<IDecoration> list = new List<IDecoration>();
            IDecoration decoretion1 = new Plant();
            IDecoration decoretion2 = new Plant();
            list.Add(decoretion1);
            list.Add(decoretion2);

            int expectedCount = 2;
            int actualCount = list.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AquaruimCounterVSCapacity()
        {
            List<IDecoration> list = new List<IDecoration>();
            var freshwaterAquarium = new FreshwaterAquarium("ASd");
            IDecoration decoretion1 = new Plant();
            IDecoration decoretion2 = new Plant();
            list.Add(decoretion1);
            list.Add(decoretion2);

            int expectedCount = 2;
            int actualCount = list.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
