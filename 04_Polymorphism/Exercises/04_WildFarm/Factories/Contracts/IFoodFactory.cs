using WildFarm.Models.Foods;

namespace WildFarm.Factories.Contracts
{
    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
