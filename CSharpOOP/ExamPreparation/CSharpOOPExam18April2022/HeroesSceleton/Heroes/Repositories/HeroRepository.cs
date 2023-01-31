using Heroes.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Repositories.Contracts
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> models;
        public HeroRepository()
        {
            this.models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => this.models;
       

        public void Add(IHero model)
        {
            this.models.Add(model);
        }

        public IHero FindByName(string name) => this.models.FirstOrDefault(h => h.Name == name);
        

        public bool Remove(IHero model)
        {
            IHero currHero = this.Models.FirstOrDefault(h=>h == model);
            if (currHero != null)
            {
                this.models.Remove(currHero);
                return true;
            }
            return false;
        }

    }
}
