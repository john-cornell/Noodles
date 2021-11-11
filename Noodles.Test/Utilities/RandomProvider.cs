using System;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.Test.Utilities
{
    public class RandomProvider
    {
        Random _random;
        List<string> _words = new List<string>();

        public RandomProvider()
        {
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public IEnumerable<decimal> GetRandomDecimals(int length)
        {
            for (int i = 0; i < length; i++) yield return GetRandomDecimal();
        }

        public decimal GetRandomDecimal() => (decimal)_random.NextDouble() * (decimal)_random.Next(10, 100);

        public IEnumerable<float> GetRandomFloats(int length)
        {
            for (int i = 0; i < length; i++) yield return (float)_random.Next(0, 16777216) / (float)10000;
        }

        public IEnumerable<int> GetRandomInts(int length, int minValue = 0, int maxValue = 65536)
        {
            for (int i = 0; i < length; i++) yield return GetRandomInt(minValue, maxValue);
        }

        public int GetRandomInt(int minValue, int maxValue) => _random.Next(minValue, maxValue);

        public string GetRandomWord()
        {
            if (_words.Count == 0)
            {
                _words = Resources.Lorem.Split(
                    new char[] { ' ', '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            return _words[_random.Next(_words.Count)];
        }

        public IEnumerable<string> GetRandomWords(int length)
        {
            for (int i = 0; i < length; i++) yield return GetRandomWord();
        }
    }
}
