using System;
using WildFarm.IO.Contracts;

namespace WildFarm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
