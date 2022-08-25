using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = 1;
            List<int> numbers = new List<int>();

            while (true)
            {
               try
               {
                    int number = ReadNumber(n, 100);
                    numbers.Add(number);
                    n = number;

                    if (numbers.Count == 10)
                    {
                        break;
                    }
               }
               catch (ArgumentException ex)
               {
                   Console.WriteLine(ex.Message);
               }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            bool isInteger = int.TryParse(input, out int result);

            if (!isInteger)
            {
                throw new ArgumentException("Invalid Number!");
            }

            int number = int.Parse(input);

            if (result <= start || result >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return number;
        }
    }
}