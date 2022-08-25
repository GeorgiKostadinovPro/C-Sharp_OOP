using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayCatch
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int exceptionCount = 0;

            while (true)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];

                try
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (cmd == "Replace")
                    {
                        int element = int.Parse(cmdArgs[2]);

                        numbers[index] = element;
                    }
                    else if (cmd == "Print")
                    {
                        int endIndex = int.Parse(cmdArgs[2]);

                        List<int> numbersToPrint = new List<int>();

                        for (int i = index; i <= endIndex; i++)
                        {
                            numbersToPrint.Add(numbers[i]);
                        }

                        Console.WriteLine(string.Join(", ", numbersToPrint));
                    }
                    else if (cmd == "Show")
                    {
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCount++;
                }

                if (exceptionCount == 3)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}