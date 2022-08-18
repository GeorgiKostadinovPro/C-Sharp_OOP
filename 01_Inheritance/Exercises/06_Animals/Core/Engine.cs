using Animals.Common;
using Animals.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Core
{
    public class Engine
    {
        private readonly ICollection<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Beast!")
            {
                string animalType = line;
                string[] animalData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Animal animal = null;

                string name = animalData[0];
                string ageInput = animalData[1];
                string gender = animalData[2];

                try
                {
                    if (string.IsNullOrWhiteSpace(ageInput))
                    {
                        throw new ArgumentException(ExceptionMessages.InvalidAnimalInput);
                    }

                    int age = int.Parse(ageInput);

                    if (animalType == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (animalType == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (animalType == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    
                    this.animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal.ToString());
            } 
        }
    }
}
