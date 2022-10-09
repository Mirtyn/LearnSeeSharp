using System;
using System.Threading;

namespace LearnSeeSharp
{
    public class Biome
    {
        public const int Forest = 0;
        public const int Swamp = 1;
        public const int Dessert = 2;
        public const int Mountain = 3;

        public int BiomeType = Forest;

        public Biome(int biomeType)
        {
            BiomeType = biomeType;
        }

        public Biome()
            : this(Biome.Forest)
        {
        }

        public override string ToString()
        {
            switch(BiomeType)
            {
                case Biome.Forest:
                    return "Forest";
                case Biome.Swamp:
                    return "Swamp";
                case Biome.Dessert:
                    return "Dessert";
                case Biome.Mountain:
                    return "Mountain";
                default:
                    return string.Empty;
            }
        }
    }
}
