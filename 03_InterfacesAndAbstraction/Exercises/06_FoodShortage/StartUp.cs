using BirthdayCelebrations.Core;
using FoodShortage.Core.Contracts;
using System;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
