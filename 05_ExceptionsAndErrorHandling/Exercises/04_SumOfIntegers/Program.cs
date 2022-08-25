using System;

namespace SumOfIntegers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(' ');

            int totalIntegersSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                string element = numbers[i];

                try
                {
                    int number = int.Parse(element);

                    totalIntegersSum += number;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally 
                { 
                    Console.WriteLine($"Element '{element}' processed - current sum: {totalIntegersSum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {totalIntegersSum}");
        }
    }
}
