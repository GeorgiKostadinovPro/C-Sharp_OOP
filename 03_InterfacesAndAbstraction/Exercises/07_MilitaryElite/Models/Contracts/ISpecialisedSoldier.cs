using MilitaryElite.Enums;

namespace MilitaryElite.Models.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public Corps Corps { get; }
    }
}
