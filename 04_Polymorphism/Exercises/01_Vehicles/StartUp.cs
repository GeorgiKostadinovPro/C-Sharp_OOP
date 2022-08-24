using System;
using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.Factories;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string carType = carArgs[0];
            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);

            string[] truckArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string truckType = truckArgs[0];
            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);

            IVehicleFactory vehicleFactory = new VehicleFactory();

            Vehicle car = vehicleFactory.CreateVehicle(carType, carFuelQuantity, carFuelConsumption);
            Vehicle truck = vehicleFactory.CreateVehicle(truckType, truckFuelQuantity, truckFuelConsumption);

            IEngine engine = new Engine(car, truck);
            engine.Run();
        }
    }
}
