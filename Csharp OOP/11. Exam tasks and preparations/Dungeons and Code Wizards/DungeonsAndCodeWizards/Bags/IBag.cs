using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Bags
{
    public interface IBag
    {
        int Capacity { get; }

        IReadOnlyCollection<Item> Items { get; }

        int Load { get; }

        void AddItem(Item item);

        Item GetItem(string name);
    }
}
