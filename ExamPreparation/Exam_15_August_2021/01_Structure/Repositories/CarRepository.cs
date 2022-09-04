namespace CarRacing.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;

    public class CarRepository : IRepository<ICar>
    {
        private readonly ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models
            => (IReadOnlyCollection<ICar>)this.models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.models.Add(model);
        }

        public ICar FindBy(string property)
        {
            return this.models.FirstOrDefault(m => m.VIN == property);
        }

        public bool Remove(ICar model)
        {
           return this.models.Remove(model);    
        }
    }
}
