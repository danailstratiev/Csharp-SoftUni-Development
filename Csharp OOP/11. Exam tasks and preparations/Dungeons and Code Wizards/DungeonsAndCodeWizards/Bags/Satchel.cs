using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Bags
{
    public class Satchel : Bag
    {
        private const int capacity = 20;

        public Satchel() 
            : base(capacity)
        {
        }
    }
}
