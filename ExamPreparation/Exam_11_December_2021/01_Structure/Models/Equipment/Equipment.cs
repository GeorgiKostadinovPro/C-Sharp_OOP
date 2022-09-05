using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        protected Equipment(double weight, decimal price)
        {

        }

        public double Weight => throw new NotImplementedException();

        public decimal Price => throw new NotImplementedException();
    }
}
