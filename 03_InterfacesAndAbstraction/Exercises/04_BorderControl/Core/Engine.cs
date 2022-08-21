using BorderControl.Core.Contracts;
using BorderControl.Models;
using BorderControl.Models.Contracts;
using System;
using System.Collections.Generic;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private readonly IDictionary<string, ICitizen> citizens;
        private readonly IDictionary<string, IRobot> robots;

        public Engine()
        {
            this.citizens = new Dictionary<string, ICitizen>();
            this.robots = new Dictionary<string, IRobot>();
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

                string nameModel = cmdArgs[0];

                if (cmdArgs.Length == 3)
                {
                    if (n == 1)
                    {
                        isFirstCitizens=true;
                        n--;
                    }

                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];

                    ICitizen citizen = new Citizen(id, nameModel, age);

                    if (!this.citizens.ContainsKey(id))
                    {
                        this.citizens.Add(id, citizen);
                    }
                }
                else
                {
                    if (n == 1)
                    {
                        isFirstCitizens = false;
                        n--;
                    }
                    
                    string id = cmdArgs[1];

                    IRobot robot = new Robot(id, nameModel);

                    if (!this.robots.ContainsKey(id))
                    {
                        this.robots.Add(id, robot);
                    }
                }
            }

            string fakeIdsIdentifier = Console.ReadLine();

            if (isFirstCitizens)
            {
                CheckDetainedCitizens(fakeIdsIdentifier);
                CheckDetainedRobots(fakeIdsIdentifier);
            }
            else 
            {
                CheckDetainedRobots(fakeIdsIdentifier);
                CheckDetainedCitizens(fakeIdsIdentifier);
            }
        }

        private void CheckDetainedRobots(string fakeIdsIdentifier)
        {
            foreach (var robot in this.robots)
            {
                if (robot.Key.EndsWith(fakeIdsIdentifier))
                {
                    Console.WriteLine(robot.Key);
                }
            }
        }

        private void CheckDetainedCitizens(string fakeIdsIdentifier)
        {
            foreach (var citizen in this.citizens)
            {
                if (citizen.Key.EndsWith(fakeIdsIdentifier))
                {
                    Console.WriteLine(citizen.Key);
                }
            }
        }
    }
}
