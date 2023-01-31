using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> models;
        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => this.models.AsReadOnly();

        public void AddItem(IMilitaryUnit model) => this.models.Add(model);


        public IMilitaryUnit FindByName(string name) => this.models.FirstOrDefault(m=>m.GetType().Name == name);
      

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unitToRemove = this.models.FirstOrDefault(m => m.GetType().Name == name);
            return this.models.Remove(unitToRemove);
        }
    }
}
