using DungeonsAndCodeWizards.Items;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace DungeonsAndCodeWizards.Bags
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;
        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            this.items = new List<Item>();
            this.Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Item> Items => this.items;

        public int Load { get => this.Items.Sum(x => x.Weight); }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (!this.items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }
    }
}
