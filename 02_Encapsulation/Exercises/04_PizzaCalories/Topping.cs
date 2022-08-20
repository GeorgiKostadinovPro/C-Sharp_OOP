using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double CaloriesPerGram
        {
            get
            {
                double totalCalories = 2 * this.Weight;

                if (this.Type == "meat")
                {
                    totalCalories *= 1.2;
                }
                else if (this.Type == "veggies")
                {
                    totalCalories *= 0.8;
                }
                else if (this.Type == "cheese")
                {
                    totalCalories *= 1.1;
                }
                else if (this.Type == "sauce")
                {
                    totalCalories *= 0.9;
                }

                return totalCalories;
            }
        }

        public double Weight
        {
            get 
            { 
                return this.weight; 
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    string type = this.Type[0].ToString().ToUpper() + this.Type.Substring(1);

                    throw new ArgumentException($"{type} " +
                        $"weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public string Type
        {
            get 
            { 
                return this.type; 
            }
            private set 
            {
                if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                {
                    string type = value[0].ToString().ToUpper() + value.Substring(1);

                    throw new ArgumentException($"Cannot place {type} on top of your pizza.");
                }

                this.type = value;
            }
        }
    }
}