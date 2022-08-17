using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private readonly Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public string RandomString()
        {
            int index = this.random.Next(0, this.Count);
            string randomElement = this[index];
            Remove(randomElement);

            return randomElement;
        }
    }
}
