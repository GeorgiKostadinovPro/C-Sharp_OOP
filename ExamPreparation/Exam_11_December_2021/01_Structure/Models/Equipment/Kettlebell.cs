using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double KettlebellInitialWeight = 10000;
        private const decimal KettlebellInitialPrice = 80;

        public Kettlebell()
            : base(KettlebellInitialWeight, KettlebellInitialPrice)
        {
        }
    }
}
