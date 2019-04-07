using P07.InfernoInfinity.Gems.ClarityTypes;

namespace P07.InfernoInfinity.Gems
{
    public abstract class Gem : IClarified
    {
        protected Gem(int strength, int agility, int vitality, ClarityType clarity)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
            this.Clarity = clarity;
        }

        public int Strength { get;private set; }

        public int Agility { get;private set; }

        public int Vitality { get;private set; }

        public ClarityType Clarity { get; private set; }

        public void ClarifyWeapon()
        {
            this.Strength += this.Clarity.StatAccelerator;
            this.Agility += this.Clarity.StatAccelerator;
            this.Vitality += this.Clarity.StatAccelerator;
        }
    }
}
