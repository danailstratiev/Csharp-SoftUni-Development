using P07.InfernoInfinity.Gems.ClarityTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P07.InfernoInfinity.Core
{
    public class GemClarifier
    {
        public ClarityType InspectClarity(string gemClarity)
        {
            switch (gemClarity)
            {
                case "Chipped":
                    return new Chipped();
                case "Regular":
                    return new Regular();
                case "Flawless":
                    return new Flawless();
                case "Perfect":
                    return new Perfect();
                default:
                    return null;
            }
        }
    }
}
