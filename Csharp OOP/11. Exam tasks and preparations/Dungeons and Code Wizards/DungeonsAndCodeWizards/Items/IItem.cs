using DungeonsAndCodeWizards.Characters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Items
{
    public interface IItem
    {
        int Weight { get; }

        void AffectCharacter(Character character);
    }
}
