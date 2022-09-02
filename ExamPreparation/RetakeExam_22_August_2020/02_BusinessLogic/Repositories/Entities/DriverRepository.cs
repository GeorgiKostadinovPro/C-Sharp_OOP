using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly ICollection<IDriver> models;
        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }

        public IReadOnlyCollection<IDriver> Models
           => (IReadOnlyCollection<IDriver>)this.models;

        public void Add(IDriver model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.Models;
        }

        public IDriver GetByName(string name)
        {
            return this.models.FirstOrDefault(d => d.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return this.models.Remove(model);
        }
    }
}
