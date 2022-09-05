using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double BoxingGlovesInitialWeight = 227;
        private const decimal BoxingGlovesInitialPrice = 120;

        public BoxingGloves()
            : base(BoxingGlovesInitialWeight, BoxingGlovesInitialPrice)
        {
        }
    }
}
