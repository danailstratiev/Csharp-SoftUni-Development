using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class PoisonPotion : Item
    {
        private const int weight = 5;

        public PoisonPotion() 
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.Health = 0;
                character.IsAlive = false;
            }
        }
    }
}
