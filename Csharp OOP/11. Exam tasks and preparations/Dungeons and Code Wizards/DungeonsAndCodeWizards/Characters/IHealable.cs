using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndCodeWizards.Characters
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
