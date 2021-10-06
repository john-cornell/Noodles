using System.Collections.Generic;
using System.Linq;
using Noodles.ML.Data;
using Noodles.ML.Data.Stores;

namespace Noodles.Test.Utilities
{
    public enum DataLoadStrategy { EnumOfEnum, RowByRow, Params }
    public class DataProvider
    {
        RandomProvider _random;

        public DataProvider()
        {
            _random = new RandomProvider();
        }

        public List<List<decimal>> GetTableListData(int columns = 0, int rows = 0)
        {
            columns = columns > 0 ? columns : _random.GetRandomInt(5, 11);
            rows = rows > 0 ? rows : _random.GetRandomInt(5, 100);

            List<List<decimal>> testData = new List<List<decimal>>();

            for (int i = 0; i < rows; i++) testData.Add(_random.GetRandomDecimals(columns).ToList());

            return testData;
        }

        public TestDataContext GetTestDataContext(DataStoreType dataStoreType, DataLoadStrategy strategy)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<List<decimal>> testData = GetTableListData();

            switch (strategy)
            {
                case DataLoadStrategy.EnumOfEnum:
                    table.Add(testData);
                    break;
                case DataLoadStrategy.RowByRow:
                    testData.ForEach(d => table.Add(d));
                    break;
                case DataLoadStrategy.Params:

                    testData = testData.Take(5).ToList();

                    table.Add(
                        testData[0].ToArray(),
                        testData[1].ToArray(),
                        testData[2].ToArray(),
                        testData[3].ToArray(),
                        testData[4].ToArray()
                        );
                    break;
                default:
                    break;
            }

            return new TestDataContext
            {
                Table = table,
                TestData = testData
            };
        }
    }

    public class TestDataContext
    {
        public DataTable Table { get; set; }
        public List<List<decimal>> TestData { get; set; }
    }
}
