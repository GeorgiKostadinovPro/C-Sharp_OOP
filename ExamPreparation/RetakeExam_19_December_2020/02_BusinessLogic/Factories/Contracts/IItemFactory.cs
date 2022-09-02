using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Factories.Contracts
{
    public interface IItemFactory
    {
        Item CreateItem(string itemName);
    }
}
