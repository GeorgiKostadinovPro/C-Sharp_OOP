using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private BunnyRepository bunniesRepository;
        private EggRepository eggsRepository;
        private Workshop workshop;
        public Controller()
        {
            this.bunniesRepository = new BunnyRepository();
            this.eggsRepository = new EggRepository();
            this.workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else 
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            this.bunniesRepository.Add(bunny);
            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunniesRepository.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException("The bunny you want to add a dye to doesn't exist!");
            }

            IDye dye = new Dye(power);

            bunny.AddDye(dye);
            return $"Successfully added dye with power {dye.Power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            this.eggsRepository.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = this.eggsRepository.FindByName(eggName);

            var bunniesToUse = this.bunniesRepository
                .Models
                .Where(b => b.Energy >= 50 && b.Dyes.Count > 0)
                .OrderByDescending(b => b.Energy)
                .ToList();

            IBunny bunny = null;

            if (bunniesToUse.Count == 0)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            while (bunniesToUse.Count > 0 && !egg.IsDone())
            {
                bunny = bunniesToUse.First();
                this.workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    this.bunniesRepository.Remove(bunny);

                    bunniesToUse = this.bunniesRepository.Models
                        .Where(b => b.Energy >= 50 && b.Dyes.Count > 0)
                        .OrderByDescending(b => b.Energy)
                        .ToList();
                }
                else if (bunny.Dyes.Count == 0)
                {
                    bunniesToUse = this.bunniesRepository.Models
                        .Where(b => b.Energy >= 50 && b.Dyes.Count > 0)
                        .OrderByDescending(b => b.Energy)
                        .ToList();
                }
            }

            if (egg.IsDone())
            {
                return $"Egg {eggName} is done.";
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.eggsRepository.Models.Count(e => e.IsDone() == true)} eggs are done!");
            sb.AppendLine("Bunnies info:");

            foreach (var bunny in this.bunniesRepository.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count(d => d.IsFinished() == false)} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
