using Raiding.Core.Contracts;
using Raiding.Factories.Contracts;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IHeroFactory heroFactory;
        private readonly ICollection<BaseHero> heroes;

        private Engine()
        {
            this.heroes = new List<BaseHero>();
        }

        public Engine(IHeroFactory heroFactory)
            : this()
        {
            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            while (true)
            {
                try
                {
                    string heroName = Console.ReadLine();
                    string heroType = Console.ReadLine();

                    BaseHero hero = this.heroFactory.CreateHero(heroType, heroName);
                    this.heroes.Add(hero);

                    if (this.heroes.Count == n)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
                
            foreach (var hero in this.heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossPower -= hero.Power;
            }
            
            if (bossPower <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else 
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
