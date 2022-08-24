using WildFarm.Core;
using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.Factories.Contracts;
using WildFarm.IO;
using WildFarm.IO.Contracts;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            IReader consoleReader = new ConsoleReader();
            IWriter consoleWriter = new ConsoleWriter();

            IEngine engine = new Engine(foodFactory, animalFactory, consoleReader, consoleWriter);
            engine.Run();
        }
    }
}
