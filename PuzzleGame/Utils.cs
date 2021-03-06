﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    class Utils
    {
        private static Random Random = new Random();

        public static double RandomDouble(double min = 0, double max = 1)
        {
            return Random.NextDouble() * (max - min) + min;
        }

        public static int RandomInt(int min = 0, int max = 0)
        {
            return (int)RandomDouble(min, max);
        }
    }
}
