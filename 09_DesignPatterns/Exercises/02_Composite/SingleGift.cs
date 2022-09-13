using System;

namespace Composite
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price)
            : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{this.Name} with price {this.Price:f2}");

            return this.Price;
        }
    }
}
