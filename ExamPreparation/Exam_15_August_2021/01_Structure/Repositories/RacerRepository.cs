namespace CarRacing.Repositories
{  
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories.Contracts;
    using CarRacing.Utilities.Messages;

    internal class RacerRepository : IRepository<IRacer>
    {
        private readonly ICollection<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models
            => (IReadOnlyCollection<IRacer>)this.models;

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this.models.Add(model);
        }

        public IRacer FindBy(string property)
        {
            return this.models.FirstOrDefault(m => m.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return this.models.Remove(model);
        }
    }
}
