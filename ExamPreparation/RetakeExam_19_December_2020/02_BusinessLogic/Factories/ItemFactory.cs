using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;
using WarCroft.Factories.Contracts;

namespace WarCroft.Factories
{
    public class ItemFactory : IItemFactory
    {
        public Item CreateItem(string itemName)
        {
			Item item;

			if (itemName == nameof(HealthPotion))
			{
				item = new HealthPotion();
			}
			else if (itemName == nameof(FirePotion))
			{
				item = new FirePotion();
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			return item;
		}
    }
}
