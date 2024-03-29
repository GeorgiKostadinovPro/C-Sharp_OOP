﻿namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        bool IsEmpty { get; set; }

        string Drive(double distance);

        void Refuel(double liters);
    }
}
