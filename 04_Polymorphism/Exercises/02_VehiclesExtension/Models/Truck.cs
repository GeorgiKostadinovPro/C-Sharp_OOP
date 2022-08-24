namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double TruckFuelConsumptionIncrement = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
            => base.FuelConsumption + TruckFuelConsumptionIncrement;

        public override void Refuel(double liters)
        {
            ValidateLiters(liters);
            ValidateIncrementedFuel(liters);

            double decreasedFuel = liters * 0.95;
            base.Refuel(decreasedFuel);
        }
    }
}
