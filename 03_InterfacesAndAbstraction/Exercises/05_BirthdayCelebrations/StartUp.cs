using BirthdayCelebrations.Core;
using BirthdayCelebrations.Core.Contracts;
using System;

namespace BirthdayCelebrations
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
