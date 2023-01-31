using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts.Entity
{
    public class Biologist : Astronaut
    {
        public Biologist(string name) : base(name, 70)
        {
        }
        public override void Breath()
        {
            int valueOfDecreasingOxygen = 5;
            if (base.Oxygen - valueOfDecreasingOxygen >= 0)
            {
                base.Oxygen -= valueOfDecreasingOxygen;
            }
            else
            {
                base.Oxygen = 0;
            }
        }
    }
}
