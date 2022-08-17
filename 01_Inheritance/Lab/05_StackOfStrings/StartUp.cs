using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();
            Console.WriteLine(stackOfStrings.IsEmpty());

            string[] strings = { "George", "Lyubo", "Kris" };

            stackOfStrings.AddRange(strings);

            Console.WriteLine(stackOfStrings.IsEmpty());
            Console.WriteLine(string.Join(", ", stackOfStrings));
        }
    }
}
