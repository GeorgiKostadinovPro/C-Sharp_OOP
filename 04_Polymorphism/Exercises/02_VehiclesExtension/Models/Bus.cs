using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double BusFuelConsumptionIncrement = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
            => this.IsEmpty ? base.FuelConsumption : base.FuelConsumption + BusFuelConsumptionIncrement;
    }
}
