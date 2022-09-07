using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly ICollection<IHero> models;

        public HeroRepository()
        {
            this.models = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => (IReadOnlyCollection<IHero>)models;

        public void Add(IHero model)
        {
            if (!this.models.Contains(model))
            {
               this.models.Add(model);
            }
        }

        public IHero FindByName(string name)
        { 
            return this.models.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        { 
            return this.models.Remove(model);
        }
    }
}
