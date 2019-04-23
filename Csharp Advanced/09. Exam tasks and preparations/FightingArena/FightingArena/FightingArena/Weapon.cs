using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Weapon
    {
        //       •	Size: int
        //•	Solidity: int
        //•	Sharpness: int

        private int size;
        private int solidity;
        private int sharpness;

        public Weapon(int size, int solidity, int sharpness)
        {
            this.Size = size;
            this.Solidity = solidity;
            this.Sharpness = sharpness;
        }

        public int Size
        {
            get { return this.size; }
            private set { size = value; }
        }


        public int Solidity
        {
            get { return this.solidity; }
            private set { solidity = value; }
        }


        public int Sharpness
        {
            get { return sharpness; }
            private set { sharpness = value; }
        }

    }
}
