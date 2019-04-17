using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            while (true)
            {
                if (this.dungeonMaster.IsGameOver() == true)
                {
                    break;
                }

                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var commands = input.Split();

                try
                {
                    switch (commands[0])
                    {
                        case "JoinParty":
                            Console.WriteLine(this.dungeonMaster.JoinParty(commands));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(this.dungeonMaster.AddItemToPool(commands));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(this.dungeonMaster.PickUpItem(commands));
                            break;
                        case "UseItem":
                            Console.WriteLine(this.dungeonMaster.UseItem(commands));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(this.dungeonMaster.UseItemOn(commands));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(this.dungeonMaster.GiveCharacterItem(commands));
                            break;
                        case "GetStats":
                            Console.WriteLine(this.dungeonMaster.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(this.dungeonMaster.Attack(commands));
                            break;
                        case "Heal":
                            Console.WriteLine(this.dungeonMaster.Heal(commands));
                            break;
                        case "EndTurn":
                            Console.WriteLine(this.dungeonMaster.EndTurn(commands));
                            break;
                        case "IsGameOver":
                            this.dungeonMaster.IsGameOver();
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Parameter Error: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Invalid Operation: {ex.Message}");
                }
            }
            Console.WriteLine("Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}
