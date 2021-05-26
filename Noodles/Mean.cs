using Noodles.MeansCalculations;
using System;

namespace Noodles
{
    public class Mean
    {
        public static ArithmeticMeanCalculator Arithmetic { get; private set; }

        static Mean()
        {
            Arithmetic = new ArithmeticMeanCalculator();
        }
    }
}
