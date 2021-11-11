using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Stores;
using Noodles.ML.Classification.DecisionTree;
using Noodles.Test.Utilities;

namespace Noodles.Test
{
    [TestClass]
    public class When_Column_Tracker
    {
        RandomProvider _random;
        DataProvider _data;

        [TestInitialize]
        public void Initialize()
        {
            _random = new RandomProvider();
            _data = new DataProvider();
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
        public void Loaded_With_Data_Table_Should_Enumerate_Over_Data_Correctly(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            ColumnTracker<decimal> tracker = new ColumnTracker<decimal>(context.Table);

            int index = 0;

            foreach (IEnumerable<decimal> column in tracker)
            {
                Assert.IsTrue(Enumerable.SequenceEqual(column, context.Table.Column[index]));

                index += 1;
            }
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
        public void Loaded_With_Data_Table_Available_Columns_Should_Be_All_Columns_Initially(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            List<int> expectedColumns = new List<int>();
            //Yes, this can be done with Enumerable.Range, but that's how I'm init'ing the available columns, so I wanted to test against something more brute force
            for (int i = 0; i < context.Table.ColumnCount; i++)
            {
                expectedColumns.Add(i);
            }

            ColumnTracker<decimal> tracker = new ColumnTracker<decimal>(context.Table);

            Assert.IsTrue(Enumerable.SequenceEqual(expectedColumns, tracker.AvailableColumns));
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
        public void Columns_Removed_Should_Enumerate_Over_Data_Correctly(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            ColumnTracker<decimal> tracker = new ColumnTracker<decimal>(context.Table);

            List<int> removedColumns = new List<int>();

            int columnsLeft = context.Table.ColumnCount;

            while (tracker.AvailableColumns.Count > 0)
            {
                foreach (int removedColumn in removedColumns)
                {
                    Assert.IsFalse(tracker.AvailableColumns.Contains(removedColumn));
                }

                int oldAvailableColumnCount = tracker.AvailableColumns.Count;
                Assert.AreEqual(columnsLeft, oldAvailableColumnCount);

                int toRemove = tracker.AvailableColumns.ToList()[_random.GetRandomInt(0, tracker.AvailableColumns.Count)];
                removedColumns.Add(toRemove);
                tracker.RemoveColumn(toRemove);

                columnsLeft -= 1;

                Queue<int> columnQueue = new Queue<int>(tracker.AvailableColumns.OrderBy(i => i));
                foreach (IEnumerable<decimal> column in tracker)
                {
                    int columnIndex = columnQueue.Dequeue();

                    Assert.IsTrue(Enumerable.SequenceEqual(context.Table.Column[columnIndex], column));
                }
            }

            Assert.AreEqual(0, columnsLeft);
        }
    }
}
