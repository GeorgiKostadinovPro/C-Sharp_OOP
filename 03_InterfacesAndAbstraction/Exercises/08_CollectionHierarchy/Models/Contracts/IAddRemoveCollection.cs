using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models.Contracts
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
