using EasterRaces.Models.Cars.Contracts;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {

        }

        public string Model => throw new NotImplementedException();

        public int HorsePower => throw new NotImplementedException();

        public double CubicCentimeters => throw new NotImplementedException();

        public double CalculateRacePoints(int laps)
        {
            throw new NotImplementedException();
        }
    }
}
