using System.Collections.Generic;

namespace TerribleWebApi.Models
{
    public class Turd
    {
        public int Id { get; set; }

        public int SmellCoefficient { get; set; }

        public int NumberOfCornKernels { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }

        public int Girth { get; set; }

        public List<string> StrangeObjects { get; set; }

        public Dictionary<int, int> LookupTable { get; set; }
    }
}