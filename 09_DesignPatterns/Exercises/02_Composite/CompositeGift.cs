using System;
using System.Collections.Generic;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;

        public CompositeGift(string name, decimal price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        } 
        
        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public bool Remove(GiftBase gift)
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
