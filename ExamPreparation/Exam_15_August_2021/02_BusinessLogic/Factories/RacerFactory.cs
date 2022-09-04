using CarRacing.Factories.Contracts;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Factories
{
    public class RacerFactory : IRacerFactory
    {
        public IRacer CreateRacer(string type, string username, string carVIN, ICar car)
        {
            IRacer racer;

            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == nameof(StreetRacer))
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            return racer;
        }
    }
}
