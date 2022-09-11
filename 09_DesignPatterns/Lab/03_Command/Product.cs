using System;

namespace Command
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public void IncreasePrice(decimal amount)
        {
            this.Price += amount;
            Console.WriteLine($"This price for the {this.Name} has been increased by {amount:f2}$.");
        }

        public void DecreasePrice(decimal amount)
        {
            decimal decreasedPrice = this.Price - amount;

            if (decreasedPrice <= 0)
            {
                throw new InvalidOperationException("You cannot decrease a product's price with amount bigger or equal to the price.");
            }

            this.Price = decreasedPrice;
            Console.WriteLine($"This price for the {this.Name} has been decreased by {amount:f2}$.");
        }

        public override string ToString()
        {
            return $"Current price for the {this.Name} product is {this.Price:f2}$.";
        }
    }
}
