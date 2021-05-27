using Noodles.MeansCalculations;
using System;

namespace Noodles
{
    public class Mean
    {
        public ArithmeticMeanCalculator Arithmetic { get; private set; }

        public Mean()
        {
            Arithmetic = new ArithmeticMeanCalculator();
        }
    }
}
