using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.models;


        public void Add(IWeapon model) => this.models.Add(model);


        public IWeapon FindByName(string name) => this.models.FirstOrDefault(w => w.Name == name);


        public bool Remove(IWeapon model)
        {
            IWeapon currWeapon = this.Models.FirstOrDefault(h => h == model);
            if (currWeapon != null)
            {
                this.models.Remove(currWeapon);
                return true;
            }
            return false;
        }
    }
}
