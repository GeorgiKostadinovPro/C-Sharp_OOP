using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private readonly FormulaOneCarRepository carRepository;
        private readonly PilotRepository pilotRepository;
        private readonly RaceRepository raceRepository;

        public Controller()
        {
            this.carRepository = new FormulaOneCarRepository();
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = this.pilotRepository
                .FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            IFormulaOneCar car = this.carRepository
                .FindByName(carModel);

            if (car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.carRepository.Remove(car);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, car.Model);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository
                .FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            IPilot pilot = this.pilotRepository
                .FindByName(pilotFullName);

            if (pilot == null || !pilot.CanRace || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = this.carRepository
                .FindByName(model);

            if (car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == nameof(Williams))
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            this.carRepository.Add(car);

            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = this.pilotRepository
                .FindByName(fullName);

            if (pilot != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);

            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = this.raceRepository
                .FindByName(raceName);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            IPilot[] pilots = this.pilotRepository.Models
                .OrderByDescending(p => p.NumberOfWins)
                .ToArray();

            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            IRace[] races = this.raceRepository.Models
                .Where(r => r.TookPlace)
                .ToArray();

            foreach (var race in races)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository
                .FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            IPilot[] fastestPilots = race.Pilots
                .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                .ToArray();

            IPilot winner = fastestPilots[0];
            winner.WinRace();

            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.PilotFirstPlace, winner.FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, fastestPilots[1].FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, fastestPilots[2].FullName, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
