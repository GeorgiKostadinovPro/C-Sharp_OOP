using System;
using System.Collections.Generic;

namespace Composite
{
    public class CompositeGift : BaseGift, IGiftOperations
    {
        private readonly ICollection<BaseGift> gifts;

        public CompositeGift(string name, decimal price) 
            : base(name, price)
        {
            this.gifts = new List<BaseGift>();
        } 
        
        public void Add(BaseGift gift)
        {
            this.gifts.Add(gift);
        }

        public bool Remove(BaseGift gift)
        {
            return this.gifts.Remove(gift);
        }
        
        public override decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0.0m;

            Console.WriteLine($"{this.Name} contains the following products with prices:");

            foreach (var gift in this.gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }
    }
}
