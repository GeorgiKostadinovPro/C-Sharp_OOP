using System;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;

            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity,fuelConsumption);
            }
            else 
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
