using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var loot = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long count = long.Parse(safe[i + 1]);

                string item = string.Empty;

                if (name.Length == 3)
                {
                    item = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    item = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    item = "Gold";
                }

                if (item == "")
                {
                    continue;
                }
                else if (input < loot.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (item)
                {
                    case "Gem":
                        if (!loot.ContainsKey(item))
                        {
                            if (loot.ContainsKey("Gold"))
                            {
                                if (count > loot["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (loot[item].Values.Sum() + count > loot["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!loot.ContainsKey(item))
                        {
                            if (loot.ContainsKey("Gem"))
                            {
                                if (count > loot["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (loot[item].Values.Sum() + count > loot["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!loot.ContainsKey(item))
                {
                    loot[item] = new Dictionary<string, long>();
                }

                if (!loot[item].ContainsKey(name))
                {
                    loot[item][name] = 0;
                }

                loot[item][name] += count;
                if (item == "Gold")
                {
                    gold += count;
                }
                else if (item == "Gem")
                {
                    gems += count;
                }
                else if (item == "Cash")
                {
                    cash += count;
                }
            }

            foreach (var x in loot)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}