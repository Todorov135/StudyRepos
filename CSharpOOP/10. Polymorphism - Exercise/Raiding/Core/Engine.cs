using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private Raid raid;
        private int bossPwoer;

        public Engine(Raid raid, int bossPower)
        {
            this.Raid = raid;
            this.BossPower = bossPower;
        }
      


        public  Raid Raid
        {
            get { return raid; }
            private set { raid = value; }
        }
        public int BossPower
        {
            get { return bossPwoer; }
            private set { bossPwoer = value; }
        }



        public void Start()
        {
            int raidPower = raid.RaidPower();
            foreach (BaseHero hero in this.Raid)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (this.BossPower > raidPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }

        }
    }
}
