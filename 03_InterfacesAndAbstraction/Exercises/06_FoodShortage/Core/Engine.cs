using FoodShortage.Core.Contracts;
using FoodShortage.Models;
using FoodShortage.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Citizen> citizens;
        private readonly ICollection<Rebel> rebels;

        public Engine()
        {
            this.citizens = new List<Citizen>();
            this.rebels = new List<Rebel>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);


                if (cmdArgs.Length == 4)
                {
                    string id = cmdArgs[2];
                    string birthDate = cmdArgs[3];

                    Citizen citizen = new Citizen(id, name, age, birthDate);

                    if (!this.citizens.Contains(citizen))
                    {
                        this.citizens.Add(citizen);
                    }
                }
                else
                {
                    string group = cmdArgs[2];

                    Rebel rebel = new Rebel(name, age, group);
                    
                    if (!this.rebels.Contains(rebel))
                    {
                        this.rebels.Add(rebel);
                    }
                }
            }

            string line = string.Empty;
            int totalPurchasedFood = 0;

            while ((line = Console.ReadLine()) != "End")
            {
                string name = line;

                Citizen citizen = this.citizens.FirstOrDefault(c => c.Name == name);
                Rebel rebel = this.rebels.FirstOrDefault(r => r.Name == name);

                if (citizen == null && rebel == null)
                {
                    continue;
                }

                if (citizen != null)
                {
                    citizen.BuyFood();
                    totalPurchasedFood += 10;
                }
                else 
                {
                    rebel.BuyFood();
                    totalPurchasedFood += 5;
                }
            }

            Console.WriteLine(totalPurchasedFood);
        }
    }
}
