using System;

namespace Composite
{
    public class SingleGift : BaseGift
    {
        public SingleGift(string name, decimal price)
            : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{this.Name} with a price {this.Price:f2}");

            return this.Price;
        }
    }
}
