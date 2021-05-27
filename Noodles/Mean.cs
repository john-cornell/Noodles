using Noodles.MeansCalculations;
using System;
using System.Collections.Generic;

namespace Noodles
{
    public class Mean
    {
        ArithmeticMeanCalculator _arithmetic { get; set; }
        GeometricMeanCalculator _geometric { get; set; }
        public Mean()
        {
            _arithmetic = new ArithmeticMeanCalculator();
            _geometric = new GeometricMeanCalculator();

        }

        public double Arithmetic(IEnumerable<int> values) => _arithmetic.Calculate(values);
        public double Arithmetic(IEnumerable<double> values) => _arithmetic.Calculate(values);

        public double Geometric(IEnumerable<int> values) => _geometric.Calculate(values);
        public double Geometric(IEnumerable<double> values) => _geometric.Calculate(values);
    }
}
