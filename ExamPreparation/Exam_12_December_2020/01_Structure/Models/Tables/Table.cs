using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;

        private readonly ICollection<IBakedFood> foodOrders;
        private readonly ICollection<IDrink> drinkOrders;

        private Table()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
            : this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public ICollection<IBakedFood> FoodOrders  => this.foodOrders;

        public ICollection<IDrink> DrinkOrders => this.drinkOrders;

        public int TableNumber
        {
            get
            {
                return this.tableNumber;
            }
            private set
            {
                this.tableNumber = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            private set
            {
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get
            {
                return this.pricePerPerson;
            }
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved { get; private set; }

        public decimal Price
            => this.FoodOrders.Sum(fo => fo.Price) 
            + this.DrinkOrders.Sum(d => d.Price)
            + this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson:f2}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
           this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
            }

            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
