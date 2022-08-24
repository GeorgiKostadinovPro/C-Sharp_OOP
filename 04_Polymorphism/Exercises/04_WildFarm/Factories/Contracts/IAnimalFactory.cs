using WildFarm.Models.Animals;

namespace WildFarm.Factories.Contracts
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(string type, string name, double weight, string thirdParam, string fourthParam = null);
    }
}
