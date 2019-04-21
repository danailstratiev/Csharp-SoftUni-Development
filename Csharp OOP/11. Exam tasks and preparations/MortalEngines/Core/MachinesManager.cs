namespace MortalEngines.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Machines;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;
        private List<ITank> allTanks;
        private List<IFighter> allFighters;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
            this.allTanks = new List<ITank>();
            this.allFighters = new List<IFighter>();
        }

        public string HirePilot(string name)
        {
            var currentPilot = this.pilots.FirstOrDefault(x => x.Name == name);

            if (currentPilot == null)
            {
                currentPilot = new Pilot(name);
                this.pilots.Add(currentPilot);

                return $"Pilot {name} hired";
            }
            else
            {
                return $"Pilot {name} is hired already";
            }
        }

        // A list of tanks might be needed
        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = this.allTanks.FirstOrDefault(x => x.Name == name);

            if (tank == null)
            {
                tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(tank);
                this.allTanks.Add(tank);

                return $"Tank {name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }
        }

        // A list of fighters might be needed
        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            var fighter = this.allFighters.FirstOrDefault(x => x.Name == name);

            if (fighter == null)
            {
                fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);
                this.allFighters.Add(fighter);

                return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var foundPilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);

            if (foundPilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            var foundMachine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (foundMachine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (foundMachine.Pilot != null)
            {
                return $"Machine {foundMachine.Name} is already occupied";
            }
            else
            {
                foundMachine.Pilot = foundPilot;
                foundPilot.AddMachine(foundMachine);

                return $"Pilot {foundPilot.Name} engaged machine {foundMachine.Name}";
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var foundAttackMachine = this.allFighters.FirstOrDefault(x => x.Name == attackingMachineName);
            var foundDefendMachine = this.allTanks.FirstOrDefault(x => x.Name == defendingMachineName);

            if (foundAttackMachine == null )
            {
                return $"Machine {foundAttackMachine.Name} could not be found";
            }

            if (foundDefendMachine == null)
            {
                return $"Machine {foundDefendMachine.Name} could not be found";
            }

            if (foundAttackMachine.HealthPoints == 0)
            {
                return $"Dead machine {foundAttackMachine.Name} cannot attack or be attacked";
            }

            if (foundDefendMachine.HealthPoints == 0)
            {
                return $"Dead machine {foundDefendMachine.Name} cannot attack or be attacked";
            }

            foundAttackMachine.Attack(foundDefendMachine);

            var message = $"Machine {foundDefendMachine.Name} was attacked by machine {foundAttackMachine.Name} - current health: {foundDefendMachine.HealthPoints:F2}";

            return message;
        }

        public string PilotReport(string pilotReporting)
        {
            var foundPilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);

            return foundPilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var foundMachine = this.machines.FirstOrDefault(x => x.Name == machineName);

            return foundMachine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var foundFighter = this.allFighters.FirstOrDefault(x => x.Name == fighterName);

            if (foundFighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }
            else
            {
                foundFighter.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }
        }

        // Check toggleMethod in Tank class!
        public string ToggleTankDefenseMode(string tankName)
        {
            var foundTank = this.allTanks.FirstOrDefault(x => x.Name == tankName);

            if (foundTank == null)
            {
                return $"Machine {foundTank} could not be found";
            }
            else
            {
                foundTank.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }
        }
    }
}