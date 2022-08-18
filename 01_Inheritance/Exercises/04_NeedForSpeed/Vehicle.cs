﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
            this.DefaultFuelConsumption = 1.25;
        }

        public double DefaultFuelConsumption { get; set; }

        public virtual double FuelConsumption => this.DefaultFuelConsumption;

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        { 
           this.Fuel -= this.FuelConsumption * kilometers;
        }
    }
}
