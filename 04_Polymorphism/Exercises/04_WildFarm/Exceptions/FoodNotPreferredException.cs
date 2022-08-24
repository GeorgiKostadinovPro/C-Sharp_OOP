using System;

namespace WildFarm.Exceptions
{
    public class FoodNotPreferredException : Exception
    {
        public FoodNotPreferredException(string message)
            : base(message)
        {

        }
    }
}
