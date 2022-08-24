using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Core.Contracts;
using WildFarm.Exceptions;
using WildFarm.Factories.Contracts;
using WildFarm.IO.Contracts;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private readonly IReader consoleReader;
        private readonly IWriter consoleWriter;
        private Engine()
        {
            this.animals = new List<Animal>();
        }

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory, IReader consoleReader, IWriter consoleWriter)
            : this()
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;

            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
        }

        public void Run()
        {
            string line = string.Empty;

            while ((line = this.consoleReader.ReadLine()) != "End")
            {
                try
                {
                    string[] animalArgs = line
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string[] foodArgs = this.consoleReader.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string foodType = foodArgs[0];
                    int foodQuantity = int.Parse(foodArgs[1]);

                    Animal animal = BuildAnimalUsingFactory(animalArgs);
                    Food food = this.foodFactory.CreateFood(foodType, foodQuantity);

                    this.consoleWriter.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                    animal.Eat(food);
                }
                catch (InvalidFactoryTypeException ifte)
                {
                    this.consoleWriter.WriteLine(ifte.Message);
                }
                catch (FoodNotPreferredException fnpe)
                {
                   this.consoleWriter.WriteLine(fnpe.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    this.consoleWriter.WriteLine(ioe.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                this.consoleWriter.WriteLine(animal.ToString());
            }
        }

        private Animal BuildAnimalUsingFactory(string[] animalArgs)
        {
            Animal animal = null;

            if (animalArgs.Length == 4)
            {
                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string thirdParam = animalArgs[3];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, weight, thirdParam);
            }
            else if (animalArgs.Length == 5)
            {
                string animalType = animalArgs[0];
                string animalName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string thirdParam = animalArgs[3];
                string fourthParam = animalArgs[4];

                animal = this.animalFactory.CreateAnimal(animalType, animalName, weight, thirdParam, fourthParam);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
