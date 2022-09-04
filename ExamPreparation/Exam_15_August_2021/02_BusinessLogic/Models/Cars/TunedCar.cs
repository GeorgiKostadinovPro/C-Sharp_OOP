namespace CarRacing.Models.Cars
{
    using System;

    public class TunedCar : Car
    {
        private const double TunedCarAvailableFuel = 65;
        private const double TunedCarFuelConsumptionPerRace = 7.5;

        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, TunedCarAvailableFuel, TunedCarFuelConsumptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();

            double horsePowerReducedBy3Percentages = this.HorsePower - this.HorsePower * 0.03;
            this.HorsePower = (int)Math.Round(horsePowerReducedBy3Percentages);
        }
    }
}
