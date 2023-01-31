using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts.Where(a => a.CanBreath))
            {
                while (planet.Items.Count > 0)
                {
                    string item = planet.Items.FirstOrDefault();
                    if (item == default)
                    {
                        break;
                    }
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    if (!astronaut.CanBreath)
                    {
                        break;
                    }

                }
            }
        }
    }
}
