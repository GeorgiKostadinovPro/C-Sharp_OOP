namespace CarRacing.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using CarRacing.Core.Contracts;
    using CarRacing.Factories;
    using CarRacing.Models.Cars;
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Maps;
    using CarRacing.Models.Maps.Contracts;
    using CarRacing.Models.Racers;
    using CarRacing.Models.Racers.Contracts;
    using CarRacing.Repositories;
    using CarRacing.Utilities.Messages;

    public class Controller : IController
    {
        private readonly CarRepository cars;
        private readonly RacerRepository racers;
        private readonly IMap map;

        private readonly CarFactory carFactory;
        private readonly RacerFactory racerFactory;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();

            this.carFactory = new CarFactory();
            this.racerFactory = new RacerFactory();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car = this.carFactory.CreateCar(type, make, model, VIN, horsePower);

            this.cars.Add(car);

            string result = string.Format(OutputMessages.SuccessfullyAddedCar, car.Make, car.Model, car.VIN);
            return result;
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = this.cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer racer = this.racerFactory.CreateRacer(type, username, carVIN, car);

            this.racers.Add(racer);

            string result = string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
            return result;
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            string result = this.map.StartRace(racerOne, racerTwo);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            IRacer[] allRacers = this.racers.Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username)
                .ToArray();

            foreach (var racer in allRacers)
            {
                sb.AppendLine($"{racer.GetType().Name}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
