using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories.Entity
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> models;
        public RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => this.models.AsReadOnly();

        public void Add(IRace model) => this.models.Add(model);
        public IRace FindByName(string name) => this.models.FirstOrDefault(r=>r.RaceName == name);
        public bool Remove(IRace model) => this.models.Remove(model);
        
    }
}
