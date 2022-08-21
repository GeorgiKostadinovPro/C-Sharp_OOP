using System.Collections.Generic;
using CollectionHierarchy.Models.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> items;

        public AddRemoveCollection()
        {
            this.items = new List<T>();
        }

        public int Add(T item)
        {
            this.items.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T item = this.items[this.items.Count - 1];
            this.items.Remove(item);

            return item;
        }
    }
}