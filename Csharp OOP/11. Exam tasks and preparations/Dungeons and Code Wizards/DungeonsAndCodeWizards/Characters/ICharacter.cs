using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Characters
{
    public interface ICharacter
    {
        //•	Name – a string (cannot be null or whitespace).
        //o Throw an ArgumentException with the message “Name cannot be null or whitespace!”
        //•	BaseHealth – a floating-point number
        //•	Health – a floating-point number(current health).
        //o Health maxes out at BaseHealth and mins out at 0. 
        //•	BaseArmor – a floating-point number
        //•	Armor – a floating-point number(current armor)
        //o Armor maxes out at BaseArmor and mins out at 0.
        //•	AbilityPoints – a floating-point number
        //•	Bag – a parameter of type Bag
        //•	Faction – a constant value with 2 possible values: CSharp and Java
        //•	IsAlive – boolean value(default value: True)
        //•	RestHealMultiplier – a floating-point number(default: 0.2), could be overriden

        string Name { get; }

        double BaseHealth { get; }

        double Health { get; set; }

        double BaseArmor { get; }

        double Armor { get; set; }

        double AbilityPoints { get; set; }

        Bag Bag { get; }

        Faction Faction { get; }

        bool IsAlive { get; }

        double RestHealMultiplier { get; }

        void TakeDamage(double hitPoints);

        void Rest();

        void UseItem(Item item);

        void UseItemOn(Item item, Character character);

        void GiveCharacterItem(Item item, Character character);

        void ReceiveItem(Item item);
    }
}
