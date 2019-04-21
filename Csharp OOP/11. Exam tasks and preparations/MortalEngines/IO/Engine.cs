using MortalEngines.Core;
using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.IO
{
    public class Engine : IEngine
    {
        private MachinesManager machineManager;

        public Engine()
        {
            this.machineManager = new MachinesManager();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != "Quit")
            {
                var commands = input.Split();
                var command = commands[0];

                try
                {
                    if (command == "HirePilot")
                    {
                        var pilotName = commands[1];

                        Console.WriteLine(this.machineManager.HirePilot(pilotName));
                    }
                    else if (command == "PilotReport")
                    {
                        var pilotName = commands[1];

                        Console.WriteLine(this.machineManager.PilotReport(pilotName));
                    }
                    else if (command == "ManufactureTank")
                    {
                        var name = commands[1];
                        var attack = double.Parse(commands[2]);
                        var defense = double.Parse(commands[3]);

                        Console.WriteLine(this.machineManager.ManufactureTank(name, attack, defense));
                    }
                    else if (command == "ManufactureFighter")
                    {
                        var name = commands[1];
                        var attack = double.Parse(commands[2]);
                        var defense = double.Parse(commands[3]);

                        Console.WriteLine(this.machineManager.ManufactureFighter(name, attack, defense));
                    }
                    else if (command == "MachineReport")
                    {
                        var name = commands[1];

                        Console.WriteLine(this.machineManager.MachineReport(name));
                    }
                    else if (command == "AggressiveMode")
                    {
                        var name = commands[1];

                        Console.WriteLine(this.machineManager.ToggleFighterAggressiveMode(name));
                    }
                    else if (command == "DefenseMode")
                    {
                        var name = commands[1];

                        Console.WriteLine(this.machineManager.ToggleTankDefenseMode(name));
                    }
                    else if (command == "Engage")
                    {
                        var pilotName = commands[1];
                        var machineName = commands[2];

                        Console.WriteLine(this.machineManager.EngageMachine(pilotName, machineName));
                    }
                    else if (command == "Attack")
                    {
                        var attackerName = commands[1];
                        var defenderName = commands[2];

                        Console.WriteLine(this.machineManager.AttackMachines(attackerName, defenderName));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                input = Console.ReadLine();
            }
        }
    }
}
