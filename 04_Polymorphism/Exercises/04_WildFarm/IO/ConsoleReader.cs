using System;
using WildFarm.IO.Contracts;

namespace WildFarm.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();

            return line;
        }
    }
}
