using P07.InfernoInfinity.Gems.ClarityTypes;

namespace P07.InfernoInfinity.Gems
{
    public class Amethyst : Gem
    {
        private const int strength = 2;
        private const int agility = 8;
        private const int vitality = 4;

        public Amethyst(ClarityType clarity) 
            : base(strength, agility, vitality, clarity)
        {
        }
    }
}
