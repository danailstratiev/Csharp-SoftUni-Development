using System;
using System.Collections.Generic;
using System.Text;

namespace P05.KingsGambitExtended
{
    public class RoyalGuard : Person
    {
        public RoyalGuard(string name) : base(name)
        {
            Lifesleft = 3;
        }

        public override int Lifesleft { get; set; }

        public override string ProtectTheKing()
        {
            return $"Royal Guard {this.Name} is defending!";
        }
    }
}
