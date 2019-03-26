using System;
using System.Linq;
using System.Collections.Generic;

namespace P08.MilitaryElite
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var myArmy = new List<Soldier>();
            var myPrivateArmy = new List<Private>();

            while (input != "End")
            {
                var currentSoldier = input.Split(" ").ToArray();
                var typeOfSoldier = currentSoldier[0];
                var id = currentSoldier[1];
                var firstName = currentSoldier[2];
                var lastName = currentSoldier[3];

                switch (typeOfSoldier)
                {
                    case "Private":
                        var salary = decimal.Parse(currentSoldier[4]);
                        var currentPrivate = new Private(id, firstName, lastName, salary);
                        myArmy.Add(currentPrivate);
                        myPrivateArmy.Add(currentPrivate);
                        break;
                    case "LieutenantGeneral":
                        salary = decimal.Parse(currentSoldier[4]);
                        var general = new LieutenantGeneral(id, firstName, lastName, salary);

                        if (currentSoldier.Length > 4)
                        {
                            for (int i = 5; i < currentSoldier.Length; i++)
                            {
                                var currentId = currentSoldier[i];

                                var foundPrivate = myPrivateArmy.FirstOrDefault(x => x.Id == currentId);

                                if (foundPrivate != null)
                                {
                                    general.Privates.Add(foundPrivate);
                                }
                            }
                        }
                        myArmy.Add(general);
                        break;
                    case "Spy":
                        var codeName = int.Parse(currentSoldier[4]);
                        var spy = new Spy(id, firstName, lastName, codeName);
                        myArmy.Add(spy);
                        break;
                    case "Engineer":
                        salary = decimal.Parse(currentSoldier[4]);
                        var corps = currentSoldier[5];

                        try
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);
                            if (currentSoldier.Length > 7)
                            {
                                for (int i = 6; i < currentSoldier.Length; i += 2)
                                {
                                    var currentRepair = new Repair(currentSoldier[i], int.Parse(currentSoldier[i + 1]));
                                    engineer.Repairs.Add(currentRepair);
                                }
                            }

                            myArmy.Add(engineer);
                        }
                        catch (Exception ex)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "Commando":
                        salary = decimal.Parse(currentSoldier[4]);
                        corps = currentSoldier[5];

                        try
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corps);

                            if (currentSoldier.Length > 7)
                            {
                                for (int i = 6; i < currentSoldier.Length; i+=2)
                                {
                                    try
                                    {
                                        var currentMission = new Mission(currentSoldier[i], currentSoldier[i + 1]);
                                        commando.Missions.Add(currentMission);
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }                                
                            }

                            myArmy.Add(commando);
                        }
                        catch (Exception)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in myArmy)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
