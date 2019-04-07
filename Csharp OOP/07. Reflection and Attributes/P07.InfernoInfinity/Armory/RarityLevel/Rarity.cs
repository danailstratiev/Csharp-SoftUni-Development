namespace P07.InfernoInfinity.Armory.RarityLevel
{
    public abstract class Rarity
    {
        protected Rarity(int damageMultiplier)
        {
            this.DamageMultiplier = damageMultiplier;
        }

        public int DamageMultiplier { get;private set; }
    }
}
