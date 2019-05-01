using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;


namespace Exam_Preparation_Greedy_Times
{
    class Program
    {
        public class Bag
        {
            public Bag()
            {
                this.Gold = 0;

                this.AllCash = 0;

                this.AllGems = 0;

                this.Gems = new Dictionary<string, BigInteger>();

                this.Cash = new Dictionary<string, BigInteger>();
            }

            public BigInteger Capacity { get; set; }

            public BigInteger Gold { get; set; }

            public Dictionary<string, BigInteger> Gems { get; set; }

            public Dictionary<string, BigInteger> Cash { get; set; }

            public BigInteger AllGems { get; set; }

            public BigInteger AllCash { get; set; }
        }
        static void Main(string[] args)
        {
            var input = BigInteger.Parse(Console.ReadLine());
            var bag = new Bag();
            bag.Capacity = input;

            var loot = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            //•	The gold amount in your bag should always be more than or equal the gem amount at any time
            //•	The gem amount should always be more than or equal the cash amount at any time

            for (int i = 0; i < loot.Length - 1; i += 2)
            {
                if (bag.Capacity <= 0)
                {
                    break;
                }

                var lootType = loot[i];
                var lootValue = BigInteger.Parse(loot[i + 1]);

                if (lootType == "Gold")
                {
                    if (bag.Capacity - lootValue >= 0)
                    {
                        bag.Gold += lootValue;
                        bag.Capacity -= lootValue;
                    }
                }
                else if (lootType.ToLower().EndsWith("gem") && lootType.Length >= 4)
                {
                    if (bag.Capacity - lootValue >= 0)
                    {
                        if (bag.Gold >= bag.AllGems + lootValue)
                        {
                            bag.Capacity -= lootValue;
                            bag.AllGems += lootValue;
                            bag.Gems.Add(lootType, lootValue);
                        }
                    }
                }
                else if (lootType.Length == 3)
                {
                    if (bag.Capacity - lootValue >= 0)
                    {
                        if (bag.AllGems >= bag.AllCash + lootValue)
                        {
                            bag.Capacity -= lootValue;
                            bag.AllCash += lootValue;
                            bag.Cash.Add(lootType, lootValue);
                        }
                    }
                }
            }

            var gold = bag.Gold;
            var gems = bag.Gems;
            var cash = bag.Cash;

            if (gold > 0)
            {
                Console.WriteLine($"<Gold> ${gold}");
                Console.WriteLine($"##Gold - {gold}");
            }
            if (gems.Count > 0)
            {
                Console.WriteLine($"<Gem> ${bag.AllGems}");
                foreach (var gem in gems.OrderByDescending(x => x.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{gem.Key} - {gem.Value}");
                }
            }
            if (cash.Count > 0)
            {
                Console.WriteLine($"<Cash> ${bag.AllCash}");
                foreach (var money in cash.OrderByDescending(x => x.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{money.Key} - {money.Value}");
                }
            }
        }
    }
}
