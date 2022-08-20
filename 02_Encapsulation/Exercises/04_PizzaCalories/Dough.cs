using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double CaloriesPerGram
        {
            get 
            {
                double totalCalories = 2 * this.Weight;

                if (this.FlourType == "white")
                {
                    totalCalories *= 1.5;
                }
                else if (this.FlourType == "wholegrain")
                {
                    totalCalories *= 1.0;
                }

                if (this.BakingTechnique == "crispy")
                {
                    totalCalories *= 0.9;
                }
                else if (this.BakingTechnique == "chewy")
                {
                    totalCalories *= 1.1;
                }
                else if (this.BakingTechnique == "homemade")
                {
                    totalCalories *= 1.0;
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
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public string BakingTechnique
        {
            get 
            { 
                return this.bakingTechnique;
            }
            private set 
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set 
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
    }
}