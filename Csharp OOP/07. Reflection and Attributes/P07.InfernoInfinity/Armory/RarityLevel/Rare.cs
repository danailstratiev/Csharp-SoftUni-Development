namespace P07.InfernoInfinity.Armory.RarityLevel
{
    public class Rare : Rarity
    {
        private const int damageMultiplier = 3;

        public Rare() 
            : base(damageMultiplier)
        {
        }
    }
}
