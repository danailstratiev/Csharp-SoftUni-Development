using DungeonsAndCodeWizards.Characters;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Items;
using DungeonsAndCodeWizards.Factories;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characterParty;
        private List<Item> itemPool;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.characterParty = new List<Character>();
            this.itemPool = new List<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.LastSurvivorRounds = 0;
        }

        public int LastSurvivorRounds { get;private set; }

        public string JoinParty(string[] args)
        {
            //"JoinParty CSharp Warrior Gosho";
            var faction = args[1];
            var characterType = args[2];
            var name = args[3];

            if (faction != "CSharp" && faction != "Java")
            {
                throw new ArgumentException($"Invalid faction " + '"' + $"{faction}" + '"' + "!");
            }

            if (characterType != "Warrior" && characterType != "Cleric")
            {
                throw new ArgumentException($"Invalid character type " + '"' + $"{characterType}" + '"' + "!");
            }

            var character = this.characterFactory.CreateCharacter(faction, characterType, name);

            this.characterParty.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[1];

            if (itemName != "HealthPotion" && itemName != "ArmorRepairKit" &&
                itemName != "PoisonPotion")
            {
                throw new ArgumentException($"Invalid item " + '"' + $"{itemName}" + '"' + "!");
            }

            var item = this.itemFactory.CreateItem(itemName);
            this.itemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[1];

            if (!this.characterParty.Any(x => x.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var character = this.characterParty.FirstOrDefault(x => x.Name == characterName);
            var lastItem = this.itemPool.Last();

            character.ReceiveItem(lastItem);
            this.itemPool.RemoveAt(this.itemPool.Count - 1);

            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[1];
            var itemName = args[2];

            if (!this.characterParty.Any(x => x.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            var character = this.characterParty.FirstOrDefault(x => x.Name == characterName);
            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[1];
            var receiverName = args[2];
            var itemName = args[3];

            if (!this.characterParty.Any(x => x.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            if (!this.characterParty.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var giver = this.characterParty.FirstOrDefault(x => x.Name == giverName);
            var receiver = this.characterParty.FirstOrDefault(x => x.Name == receiverName);

            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[1];
            var receiverName = args[2];
            var itemName = args[3];

            if (!this.characterParty.Any(x => x.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            if (!this.characterParty.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var giver = this.characterParty.FirstOrDefault(x => x.Name == giverName);
            var receiver = this.characterParty.FirstOrDefault(x => x.Name == receiverName);

            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var character in this.characterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                var status = "";
                if (character.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[1];
            var receiverName = args[2];

            if (!this.characterParty.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            if (!this.characterParty.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var attacker = this.characterParty.FirstOrDefault(x => x.Name == attackerName);
            var receiver = this.characterParty.FirstOrDefault(x => x.Name == receiverName);

            if (attacker.GetType().Name != "Warrior")
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var currentAttacker = attacker as Warrior;

            currentAttacker.Attack(receiver);

            var sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {currentAttacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[1];
            var receiverName = args[2];

            if (!this.characterParty.Any(x => x.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (!this.characterParty.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            var healer = this.characterParty.FirstOrDefault(x => x.Name == healerName);
            var receiver = this.characterParty.FirstOrDefault(x => x.Name == receiverName);

            if (healer.GetType().Name != "Cleric")
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            var currentHealer = healer as Cleric;

            currentHealer.Heal(receiver);

            var sb = new StringBuilder();

            sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }

        public string EndTurn(string[] args)
        {
            var aliveCharacters = new List<Character>();

            foreach (var character in this.characterParty.Where(x => x.IsAlive == true))
            {
                aliveCharacters.Add(character);
            }

            var sb = new StringBuilder();

            for (int i = 0; i < aliveCharacters.Count; i++)
            {
                var healthBeforeRest = aliveCharacters[i].Health;
                aliveCharacters[i].Rest();
                var currentHealth = aliveCharacters[i].Health;

                var aliveCharacter = aliveCharacters[i];

                sb.AppendLine($"{aliveCharacter.Name} rests ({healthBeforeRest} => {currentHealth})");
            }

            if (aliveCharacters.Count <= 1 )
            {
                this.LastSurvivorRounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (this.LastSurvivorRounds > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
