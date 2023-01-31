using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private ICollection<IVessel> models;
        public VesselRepository()
        {
            this.models = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => this.models.ToImmutableList();

        public void Add(IVessel model) => this.models.Add(model);


        public IVessel FindByName(string name) => this.models.FirstOrDefault(v => v.Name == name);


        public bool Remove(IVessel model) => this.models.Remove(model);

    }
}
