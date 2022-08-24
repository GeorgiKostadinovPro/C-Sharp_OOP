using Raiding.Factories.Contracts;
using Raiding.Models;
using System;

namespace Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public BaseHero CreateHero(string type, string name)
        {
            BaseHero hero = null;

            if (type == nameof(Druid))
            {
                hero = new Druid(name);
            }
            else if (type == nameof(Paladin))
            {
                hero = new Paladin(name);
            }
            else if (type == nameof(Rogue))
            {
                hero = new Rogue(name);
            }
            else if (type == nameof(Warrior))
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero!");
            }

            return hero;
        }
    }
}
