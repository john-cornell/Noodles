using System;
using System.Collections.Generic;
using System.Text;

namespace Noodles.Test.Utilities
{
    public class RandomProvider
    {
        Random _random;

        public RandomProvider()
        {
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public IEnumerable<double> GetRandomDoubles(int length)
        {
            for (int i = 0; i < length; i++) yield return (double) _random.Next(0, 16777216) / (double) 10000;
        }

        public IEnumerable<int> GetRandomInts(int length, int maxValue = 65536, int minValue = 0)
        {
            for (int i = 0; i < length; i++) yield return _random.Next(minValue, maxValue);
        }
    }
}
