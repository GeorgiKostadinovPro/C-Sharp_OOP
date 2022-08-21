using MilitaryElite.Enums;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }
    }
}
