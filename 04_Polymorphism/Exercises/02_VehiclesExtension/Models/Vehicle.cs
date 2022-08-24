using System;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity 
        {
            get
            {
                return fuelQuantity;
            }
            private set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                this.fuelQuantity = value;
            }
        }

        public virtual double FuelConsumption 
        {
            get
            { 
               return this.fuelConsumption;
            }
            private set 
            { 
               this.fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get 
            { 
                return this.tankCapacity; 
            }
            private set 
            {
                this.tankCapacity = value;
            }
        }

        public bool IsEmpty { get; set; }

        public string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            ValidateLiters(liters);
            ValidateIncrementedFuel(liters);

            this.fuelQuantity += liters;
        }

        public void ValidateLiters(double liters)
        { 
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }

        public void ValidateIncrementedFuel(double liters)
        {
            double incrementFuel = this.FuelQuantity + liters;

            if (incrementFuel > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
