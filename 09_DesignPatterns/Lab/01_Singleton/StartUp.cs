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
        }
    }
}
