using Heroes.Models.Contracts;
using Heroes.Models.Weapons;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly ICollection<IWeapon> models;
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)models;

        public void Add(IWeapon model)
        {
            if (!this.models.Contains(model))
            {
                this.models.Add(model);
            }
        }

        public IWeapon FindByName(string name)
        { 
            return this.models.FirstOrDefault(w => w.Name == name);
        }

        public bool Remove(IWeapon model)
        { 
            return this.models.Remove(model);
        }
    }
}
