using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly ICollection<Topping> toppings;

        private Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough)
            : this()
        {
            this.Name = name;
            this.Dough = dough;
        }

        public double TotalCalories
          => this.toppings.Count > 0 
            ? this.Dough.CaloriesPerGram + this.toppings.Sum(t => t.CaloriesPerGram) 
            : this.Dough.CaloriesPerGram;
        
        public int NumberOfToppings => this.toppings.Count;

        public Dough Dough { get; set; }

        public string Name
        { 
            get 
            { 
                return this.name; 
            }
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value; 
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            if (!this.toppings.Contains(topping))
            {
                this.toppings.Add(topping);
            }
        }
    }
}
