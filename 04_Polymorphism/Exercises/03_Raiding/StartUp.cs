using Raiding.Core;
using Raiding.Core.Contracts;
using Raiding.Factories;
using Raiding.Factories.Contracts;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IHeroFactory heroFactory = new HeroFactory();   
            IEngine engine = new Engine(heroFactory);
            engine.Run();
        }
    }
}
