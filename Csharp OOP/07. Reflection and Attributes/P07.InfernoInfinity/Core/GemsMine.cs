using P07.InfernoInfinity.Gems;
using P07.InfernoInfinity.Gems.ClarityTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P07.InfernoInfinity.Core
{
    public class GemsMine
    {
        public Gem MineAGem(ClarityType clarityType, string gemName)
        {
            switch (gemName)
            {
                case "Amethyst":
                    return new Amethyst(clarityType);
                case "Emerald":
                    return new Emerald(clarityType);
                case "Ruby":
                    return new Ruby(clarityType);
                default:
                    return null;
            }
        }
    }
}
