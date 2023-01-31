using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts.Entity
{
    public class Meteorologist : Astronaut
    {
        public Meteorologist(string name) : base(name, 90)
        {
        }
    }
}
