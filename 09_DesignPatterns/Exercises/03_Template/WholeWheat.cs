using System;

namespace Template
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine($"Gathering ingredients for WholeWheat bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat bread. (15 minutes)");
        }

        public override void Slice()
        {
            base.Slice();

            Console.WriteLine($"The Whole Wheat bread should be cut on 10 slices.");
        }
    }
}
