﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerribleWebApi.Models
{
    public class Turd
    {
        public int SmellCoefficient { get; set; }

        public int NumberOfCornKernels { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }

        public int Girth { get; set; }

        public List<string> StrangeObjects { get; set; }

        public Dictionary<int, int> LookupTable { get; set; }
    }
}