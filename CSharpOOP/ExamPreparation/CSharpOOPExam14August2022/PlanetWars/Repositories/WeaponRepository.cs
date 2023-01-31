using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> models;
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.models.AsReadOnly();
        public void AddItem(IWeapon model) => this.models.Add(model);


        public IWeapon FindByName(string name) => this.models.FirstOrDefault(m=>m.GetType().Name == name);


        public bool RemoveItem(string name)
        {
            IWeapon weaponToRemove = this.models.FirstOrDefault(m => m.GetType().Name == name);
            return this.models.Remove(weaponToRemove);
        }


    }
}
