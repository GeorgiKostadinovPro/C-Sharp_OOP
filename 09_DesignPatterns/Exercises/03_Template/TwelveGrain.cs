﻿using System;

namespace Template
{
    public class TwelveGrain : Bread
    {   
        public override void MixIngredients()
        {
            Console.WriteLine($"Gathering ingredients for 12-Grain bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain bread. (25 minutes)");
        }
    }
}
