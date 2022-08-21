using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models.Contracts
{
    public interface IAddCollection<T>
    {
        int Add(T item);
    }
}
