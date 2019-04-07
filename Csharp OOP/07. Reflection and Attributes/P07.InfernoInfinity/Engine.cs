using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using P07.InfernoInfinity.Armory;
using P07.InfernoInfinity.Core;

namespace P07.InfernoInfinity
{
    public class Engine
    {
        public void Run()
        {
            var weaponArsenal = new List<Weapon>();

            var input = Console.ReadLine().Split(";");

            while (input[0] != "END")
            {
                var command = input[0];

                if (command == "Create")
                {
                    var weaponToCreate = input[1].Split(" ");
                    var weaponRarity = weaponToCreate[0];
                    var marketPlace = new MarketPlace();
                    var rarityLevel = marketPlace.EstimateRarityLevel(weaponRarity);
                    var weaponType = weaponToCreate[1];
                    var weaponName = input[2];
                    var forge = new WeaponsForge();
                    var weapon = forge.ForgeAWeapon(weaponType, rarityLevel, weaponName);
                    weapon.CalculateWeaponRarity();
                    weaponArsenal.Add(weapon);
                }
                else if (command == "Add")
                {
                    var weaponName = input[1];
                    var socketIndex = int.Parse(input[2]);
                    var gemInfo = input[3].Split(" ");
                    var gemClarity = gemInfo[0];
                    var gemClarifier = new GemClarifier();
                    var currentGemClarity = gemClarifier.InspectClarity(gemClarity);
                    var gemType = gemInfo[1];
                    var gemsMine = new GemsMine();
                    var gem = gemsMine.MineAGem(currentGemClarity, gemType);
                    var currentWeapon = weaponArsenal.FirstOrDefault(x => x.Name == weaponName);
                    currentWeapon.Add(gem, socketIndex);
                }
                else if (command == "Remove")
                {
                    var weaponName = input[1];
                    var socketIndex = int.Parse(input[2]);
                    var currentWeapon = weaponArsenal.FirstOrDefault(x => x.Name == weaponName);

                    currentWeapon.Remove(socketIndex);
                }
                else if (command == "Print")
                {
                    var name = input[1];
                    var weapon = weaponArsenal.FirstOrDefault(x => x.Name == name);
                    var weaponToPrint = weapon;
                    weaponToPrint.CalculateWeaponTotalPower();
                    weaponToPrint.CalculateFinalWeaponDamage();
                    Console.WriteLine(weaponToPrint);
                }

                input = Console.ReadLine().Split(";");
            }

        }
    }
}
