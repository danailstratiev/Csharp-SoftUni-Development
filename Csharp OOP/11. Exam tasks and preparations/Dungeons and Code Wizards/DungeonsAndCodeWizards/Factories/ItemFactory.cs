using DungeonsAndCodeWizards.Items;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var itemType = assembly.GetTypes().First(x => x.Name == itemName);
            Item item = (Item)Activator.CreateInstance(itemType, true);

            return item;
        }
    }
}
