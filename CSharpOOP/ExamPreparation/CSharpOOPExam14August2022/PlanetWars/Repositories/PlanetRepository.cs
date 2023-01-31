using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void AddItem(IPlanet model) => this.models.Add(model);


        public IPlanet FindByName(string name) => this.models.FirstOrDefault(p=>p.Name == name);
        

        public bool RemoveItem(string name)
        {
            IPlanet planetToRemove = this.models.FirstOrDefault(p => p.Name == name);
            return this.models.Remove(planetToRemove);
        }
    }
}
