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

        public IEnumerable<int> GetRandomInts(int length, int maxValue = Int32.MaxValue, int minValue = 0)
        {
            for (int i = 0; i < length; i++) yield return _random.Next(minValue, maxValue);
        }
    }
}
