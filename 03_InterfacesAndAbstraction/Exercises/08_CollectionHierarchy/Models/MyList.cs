using System.Collections.Generic;
using CollectionHierarchy.Models.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : IMyList<T>
    {
        private readonly List<T> items;

        public MyList()
        {
            this.items = new List<T>();
        }

        public int Used => this.items.Count;

        public int Add(T item)
        {
            this.items.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T item = this.items[0];
            this.items.Remove(item);

            return item;
        }
    }
}