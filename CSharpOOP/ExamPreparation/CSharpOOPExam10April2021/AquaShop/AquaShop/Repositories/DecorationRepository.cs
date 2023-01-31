using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models;
        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => this.models.ToList();

        public void Add(IDecoration model) => this.models.Add(model);

        public bool Remove(IDecoration model) => this.models.Remove(model);

        public IDecoration FindByType(string type) => this.Models.FirstOrDefault(m=>m.GetType().Name == type);
       
    }
}
