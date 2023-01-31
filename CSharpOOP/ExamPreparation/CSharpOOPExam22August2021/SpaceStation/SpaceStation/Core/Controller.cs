using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Astronauts.Entity;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronauts;
        private IRepository<IPlanet> planets;
        private int exploredPlanetsCount = 0;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }
            astronauts.Add(astronaut);
            return $"Successfully added {type}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (string item in items)
            {
                planet.Items.Add(item);
            }
            this.planets.Add(planet);
            return $"Successfully added Planet: {planetName}!";
        }
        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FindByName(astronautName);
            if (astronaut == default)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }
            this.astronauts.Remove(astronaut);
            return $"Astronaut {astronautName} was retired!";
        }
        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> sortedAstronauts = this.astronauts.Models.Where(a => a.Oxygen >= 60).ToList();
            if (sortedAstronauts.Count==0)
            {
                throw new InvalidOperationException("You need at least one astronaut to explore the planet");
            }
            IPlanet planetToExplore = this.planets.FindByName(planetName);
            IMission mission = new Mission();
            mission.Explore(planetToExplore, sortedAstronauts);
            exploredPlanetsCount++;
            int deadAstronauts = sortedAstronauts.Count(a=>a.Oxygen == 0);
            return $"Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (IAstronaut astronaut in this.astronauts.Models)
            {
                string printBag = astronaut.Bag.Items.Count > 0 ? string.Join(", ", astronaut.Bag.Items) : "none";

                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {printBag}");
            }
            return sb.ToString().TrimEnd();
        }

        
    }
}
