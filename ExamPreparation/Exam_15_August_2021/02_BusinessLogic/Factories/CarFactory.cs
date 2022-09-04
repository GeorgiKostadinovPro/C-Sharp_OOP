using CarRacing.Factories.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Factories
{
    public class CarFactory : ICarFactory
    {
        public ICar CreateCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            if (type == nameof(SuperCar))
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            return car;
        }
    }
}
