using System.Collections.Generic;
using CollectionHierarchy.Models.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly ICollection<T> items;

        public AddCollection()
        {
            this.items = new List<T>();
        }

        public int Add(T item)
        {
            this.items.Add(item);

            return this.items.Count - 1;
        }
    }
}
