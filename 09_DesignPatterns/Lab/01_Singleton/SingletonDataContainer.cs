using System;
using System.Collections.Generic;
using System.IO;

namespace Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    { 
        private static readonly object syncRoot  = new object();
        private readonly IDictionary<string, int> cities;
        
        private SingletonDataContainer()
        {
            this.cities = new Dictionary<string, int>();

            this.InitializeSingletonObject();
        }

        private static volatile SingletonDataContainer instance = null;

        public static SingletonDataContainer Instance
        {
            get 
            {
                lock(syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new SingletonDataContainer();
                    }
                }
                
                return instance;
            }
        }

        public int GetPopulation(string cityName)
        {
            int population = this.cities[cityName];

            return population;
        }

        private void InitializeSingletonObject()
        {
            Console.WriteLine("Initializing singleton object");

            string[] elements = File.ReadAllLines("../../../cities.txt");

            for (int i = 0; i < elements.Length; i+=2)
            {
                string cityName = elements[i];
                int population = int.Parse(elements[i+1]);

                if (!this.cities.ContainsKey(cityName))
                {
                    this.cities.Add(cityName, 0);
                }

                this.cities[cityName] = population;
            }
        }
    }
}
