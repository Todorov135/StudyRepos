using Raiding.Factories.Interfaces;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Raiding.Factories
{
    public class HeroFactory :  IBaseHero
    {
       

        public BaseHero CreateHero(string name, string type)
        {
            BaseHero hero=null;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            if (hero == null)
            {
                throw new ArgumentException("Invalid hero!");
            }
                return hero;
            
            
        }
    }
}
