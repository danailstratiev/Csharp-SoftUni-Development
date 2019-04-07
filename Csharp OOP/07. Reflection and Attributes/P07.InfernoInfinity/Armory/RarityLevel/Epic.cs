namespace P07.InfernoInfinity.Armory.RarityLevel
{
    public class Epic : Rarity
    {
        private const int damageMultiplier = 5;

        public Epic() 
            : base(damageMultiplier)
        {
        }
    }
}
