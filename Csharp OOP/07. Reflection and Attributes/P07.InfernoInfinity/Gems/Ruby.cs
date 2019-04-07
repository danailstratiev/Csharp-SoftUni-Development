using P07.InfernoInfinity.Gems.ClarityTypes;

namespace P07.InfernoInfinity.Gems
{
    public class Ruby : Gem
    {
        private const int strength = 7;
        private const int agility = 2;
        private const int vitality = 5;

        public Ruby(ClarityType clarity) 
            : base(strength, agility, vitality, clarity)
        {
        }
    }
}
