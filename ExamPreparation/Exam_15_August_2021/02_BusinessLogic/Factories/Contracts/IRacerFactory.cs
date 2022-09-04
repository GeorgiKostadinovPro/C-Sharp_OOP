using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Factories.Contracts
{
    public interface IRacerFactory
    {
        IRacer CreateRacer(string type, string username, string carVIN, ICar car);
    }
}
