using System;
using VehiclesExtension.Core;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.Models;

namespace VehiclesExtension
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
            double carTankCapacity = double.Parse(carArgs[3]);

            string[] truckArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string truckType = truckArgs[0];
            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);
            double truckTankCapacity = double.Parse(truckArgs [3]);

            string[] busArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string busType = busArgs[0];    
            double busFuelQuantity = double.Parse(busArgs[1]);
            double busFuelConsumption = double.Parse(busArgs[2]);
            double busTankCapacity = double.Parse(busArgs[3]);

            IVehicleFactory vehicleFactory = new VehicleFactory();

            try
            {
                Vehicle car = vehicleFactory.CreateVehicle(carType, carFuelQuantity, carFuelConsumption, carTankCapacity);
                Vehicle truck = vehicleFactory.CreateVehicle(truckType, truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
                Vehicle bus = vehicleFactory.CreateVehicle(busType, busFuelQuantity, busFuelConsumption, busTankCapacity);

                IEngine engine = new Engine(car, truck, bus);
                engine.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
