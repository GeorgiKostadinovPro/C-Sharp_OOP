using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("George");
            randomList.Add("Lyubo");
            randomList.Add("Kris");

            Console.WriteLine(string.Join(", ", randomList));

            string randomElement = randomList.RandomString();

            Console.WriteLine(randomElement);
            Console.WriteLine(string.Join(", ", randomList));
        }
    }
}
