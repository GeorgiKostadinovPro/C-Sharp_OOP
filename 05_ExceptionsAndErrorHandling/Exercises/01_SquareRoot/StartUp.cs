using System;

namespace SquareRoot
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }

                double squareRoot = Math.Sqrt(number);
                Console.WriteLine(squareRoot);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
