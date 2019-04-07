using P07.InfernoInfinity.Armory.RarityLevel;

namespace P07.InfernoInfinity.Core
{
    public class MarketPlace
    {
        public Rarity EstimateRarityLevel(string rarityLevel)
        {
            switch (rarityLevel)
            {
                case "Common":
                    return new Common();
                case "Rare":
                    return new Rare();
                case "Uncommon":
                    return new Uncommon();
                case "Epic":
                    return new Epic();
                default:
                    return null;
            }

        }
    }
}
