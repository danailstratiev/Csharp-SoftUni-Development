using P07.InfernoInfinity.Gems.ClarityTypes;

namespace P07.InfernoInfinity.Gems
{
    public class Emerald : Gem
    {
        private const int strength = 1;
        private const int agility = 4;
        private const int vitality = 9;

        public Emerald(ClarityType clarity) 
            : base(strength, agility, vitality, clarity)
        {
        }
    }
}
