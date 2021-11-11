using System;
using System.Collections.Generic;

namespace Noodles.Utilities.Combinations
{
    public class IndexCombinationProvider
    {
        public IEnumerable<Tuple<int, int>> GetIndexPairCombinations(int itemCount)
        {
            int i = 0;

            while (i < itemCount)
            {
                int start = i + 1;
                for (int j = start; j <= itemCount; j++)
                {
                    yield return new Tuple<int, int>(i, j);
                }

                i++;
            }
        }
    }
}
