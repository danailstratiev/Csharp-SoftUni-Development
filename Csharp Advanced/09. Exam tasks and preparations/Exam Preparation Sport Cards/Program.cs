using System;
using System.Linq;
using System.Collections.Generic;

namespace Exam_Preparation_Sport_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var sportCards = new Dictionary<string, Dictionary<string, decimal>>();

            while (input != "end")
            {
                var currentCard = input.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (currentCard.Count == 3)
                {
                    var cardName = currentCard[0];
                    var sportType = currentCard[1];
                    var price = decimal.Parse(currentCard[2]);

                    if (!sportCards.ContainsKey(cardName))
                    {
                        sportCards[cardName] = new Dictionary<string, decimal>();
                        sportCards[cardName].Add(sportType, price);
                    }
                    else
                    {
                        if (!sportCards[cardName].ContainsKey(sportType))
                        {
                            sportCards[cardName].Add(sportType, price);
                        }
                        else
                        {
                            sportCards[cardName][sportType] = price;
                        }
                    }
                }
                else
                {
                    var check = currentCard[0];
                    var cardName = currentCard[1];

                    if (!sportCards.ContainsKey(cardName))
                    {
                        Console.WriteLine($"{cardName} is not available!");
                    }
                    else
                    {
                        Console.WriteLine($"{cardName} is available!");
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var card in sportCards.OrderByDescending(x => x.Value.Count))
            {
                var currentCardName = card.Key;
                var sports = card.Value;

                Console.WriteLine($"{currentCardName}:");
                foreach (var sport in sports.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"  -{sport.Key} - {sport.Value:F2}");
                }
            }
        }

    }
}
