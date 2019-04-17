using DungeonsAndCodeWizards.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Items
{
    public abstract class Item : IItem
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; private set; }

        public virtual void AffectCharacter(Character character)
        {
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
