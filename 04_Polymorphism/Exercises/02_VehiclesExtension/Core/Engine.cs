using System;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Models;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;

        public Engine(Vehicle car, Vehicle truck, Vehicle bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                string vehicleType = cmdArgs[1];

                try
                {
                    if (cmd == "Drive")
                    {
                        double distance = double.Parse(cmdArgs[2]);
                    
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(this.car.Drive(distance));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(this.truck.Drive(distance));
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.bus.IsEmpty = false;
                            Console.WriteLine(this.bus.Drive(distance));
                        }
                    }
                    else if (cmd == "DriveEmpty")
                    {
                        double distance = double.Parse(cmdArgs[2]);
                    
                        this.bus.IsEmpty = true;
                        Console.WriteLine(this.bus.Drive(distance));
                    }
                    else if (cmd == "Refuel")
                    {
                        double liters = double.Parse(cmdArgs[2]);
                    
                        if (vehicleType == "Car")
                        {
                            this.car.Refuel(liters);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.truck.Refuel(liters);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.bus.Refuel(liters);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}
