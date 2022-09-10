using System;

namespace Singleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SingletonDataContainer db = SingletonDataContainer.Instance;

            int sofiaPopulation = db.GetPopulation("Sofia");
            Console.WriteLine($"Sofia - {sofiaPopulation}");

            SingletonDataContainer db2 = SingletonDataContainer.Instance;

            int newYorkPopulation = db2.GetPopulation("Tokyo");
            Console.WriteLine($"New York - {newYorkPopulation}");
        }
    }
}
