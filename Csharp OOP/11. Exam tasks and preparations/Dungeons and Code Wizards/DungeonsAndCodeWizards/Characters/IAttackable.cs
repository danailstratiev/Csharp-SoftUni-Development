using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public interface IAttackable
    {
        void Attack(Character character);
    }
}
