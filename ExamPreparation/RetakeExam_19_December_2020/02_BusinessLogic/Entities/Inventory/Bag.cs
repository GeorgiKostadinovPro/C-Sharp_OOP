using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private readonly ICollection<Item> items;

        private Bag()
        {
            this.Capacity = 100;

            this.items = new List<Item>();
        }
        protected Bag(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }

        public int Capacity 
        {
            get
            {
                return this.capacity;
            }
            set
            {
                this.capacity = value;
            }
        }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items 
            => (IReadOnlyCollection<Item>)this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.items
                .FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
