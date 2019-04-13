using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit
{
    public class RoyalGuard : Person
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override string ProtectTheKing()
        {
            return $"Royal Guard {this.Name} is defending!";
        }
    }
}
