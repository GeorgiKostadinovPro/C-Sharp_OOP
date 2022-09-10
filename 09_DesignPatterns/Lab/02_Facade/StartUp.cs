using System;

namespace Facade
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
                .Info
                  .WithType("BMW")
                  .WithColor("Black")
                  .WithNumberOfDoors(4)
                .Address
                  .InCity("Leipzig")
                  .AtAddress("BMW-Allee 1, 04349 Leipzig, Germany")
                .Build();

            Console.WriteLine(car.ToString());
        }
    }
}
