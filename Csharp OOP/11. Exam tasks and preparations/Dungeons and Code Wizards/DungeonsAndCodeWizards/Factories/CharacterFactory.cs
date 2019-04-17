using DungeonsAndCodeWizards.Characters;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var factioN = Enum.Parse<Faction>(faction);

            var typeOfCharacter = assembly.GetTypes().First(x => x.Name == characterType);
            Character character = (Character)Activator.CreateInstance(typeOfCharacter, new object[] {name, factioN });

            return character;
        }
    }
}
