using BirthdayCelebrations.Core.Contracts;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private readonly IDictionary<string, ICitizen> citizens;
        private readonly ICollection<IPet> pets;

        public Engine()
        {
            this.citizens = new Dictionary<string, ICitizen>();
            this.pets = new List<IPet>();
        }

        public void Run()
        {
            string line = string.Empty;
            bool isFirstCitizens = false;
            int n = 1;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                string nameModel = cmdArgs[1];
                string birthDate = cmdArgs[cmdArgs.Length - 1];

                if (cmd == "Citizen")
                {
                    if (n == 1)
                    {
                        isFirstCitizens=true;
                        n--;
                    }
                    
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];

                    ICitizen citizen = new Citizen(id, nameModel, age, birthDate);

                    if (!this.citizens.ContainsKey(id))
                    {
                        this.citizens.Add(id, citizen);
                    }
                }
                else if (cmd == "Pet")
                {
                    if (n == 1)
                    {
                        isFirstCitizens = false;
                        n--;
                    }

                    IPet pet = new Pet(nameModel, birthDate);

                    if (!this.pets.Contains(pet))
                    {
                        this.pets.Add(pet);
                    }
                }
            }

            string year = Console.ReadLine();

            if (isFirstCitizens)
            {
                CheckCitizensBirthDate(year);
                CheckPetsBirthDate(year);
            }
            else 
            {
                CheckPetsBirthDate(year);
                CheckCitizensBirthDate(year);
            }
        }

        private void CheckPetsBirthDate(string year)
        {
            foreach (var pet in this.pets)
            {
                if (pet.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(pet.BirthDate);
                }
            }
        }

        private void CheckCitizensBirthDate(string year)
        {
            foreach (var citizen in this.citizens)
            {
                if (citizen.Value.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(citizen.Value.BirthDate);
                }
            }
        }
    }
}
