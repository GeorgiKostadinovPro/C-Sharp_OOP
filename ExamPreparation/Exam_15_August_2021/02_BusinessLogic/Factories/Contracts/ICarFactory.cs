using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Factories.Contracts
{
    public interface ICarFactory
    {
        ICar CreateCar(string type, string make, string model, string VIN, int horsePower);
    }
}
