using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.Data.Stores;
using Noodles.Test.Utilities;

namespace Noodles.Test
{
    [TestClass]
    public class When_Data_Added_To_DataStore
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
        public void Column_Data_Should_Be_Correct(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            Assert.AreEqual(context.TestData.First().Count, context.Table.ColumnCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        public void Row_Data_Should_Be_Correct(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            Assert.AreEqual(context.TestData.Count, context.Table.RowCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        public void Should_Access_Correct_Data_By_Index(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            AssertTestDataCorrect(context.Table, context.TestData);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, false, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, false, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, false, true)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowException_If_NegativeIndexCalled(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy,
            bool negativeRow, bool negativeColumn)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            //Start random at 1 to ensure a negative number is given when *-1
            int rowToRetrieve = _random.GetRandomInt(1, context.Table.RowCount) * (negativeRow ? -1 : 1);
            int columnToRetrieve = _random.GetRandomInt(1, context.Table.ColumnCount) * (negativeColumn ? -1 : 1);

            decimal iDontExist = context.Table.Data[rowToRetrieve, columnToRetrieve];
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, false, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, false, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, false, true)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowException_If_HighIndexCalled(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy,
            bool highRow, bool highColumn)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            int rowToRetrieve = highRow ? context.Table.RowCount : _random.GetRandomInt(0, context.Table.RowCount);
            int columnToRetrieve = highColumn ? context.Table.ColumnCount : _random.GetRandomInt(0, context.Table.ColumnCount);

            decimal iDontExist = context.Table.Data[rowToRetrieve, columnToRetrieve];
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        public void ShouldCorrectlyModifyData_ChangedByIndex(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            int rowToModify = _random.GetRandomInt(0, context.Table.RowCount);
            int columnToModify = _random.GetRandomInt(0, context.Table.ColumnCount);

            Assert.AreEqual(context.TestData[rowToModify][columnToModify], context.Table.Data[rowToModify, columnToModify]);

            decimal newData = _random.GetRandomDecimal();

            context.Table.Data[rowToModify, columnToModify] = newData;

            Assert.AreEqual(newData, context.Table.Data[rowToModify, columnToModify]);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        public void ShouldCorrectlyUpdate_When_DataRowInserted(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);
            int sourceRow = _random.GetRandomInt(0, context.Table.RowCount);
            int destinationRow;
            do
            {
                destinationRow = _random.GetRandomInt(0, context.Table.RowCount);
            }
            while (sourceRow == destinationRow);

            context.Table.Row[sourceRow] = context.Table.Row[destinationRow];


            AssertDataRowsAreCorrect(context.Table.Row[sourceRow], context.Table.Row[destinationRow]);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowException_IfRowDataInsert_ColumnSizesDoNotMatch(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);
            TestDataContext context2;

            do
            {
                context2 = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);
            }
            while (context2.Table.ColumnCount == context.Table.ColumnCount);

            int sourceRow = _random.GetRandomInt(0, context.Table.RowCount);
            int destinationRow = _random.GetRandomInt(0, context2.Table.RowCount);

            context.Table.Row[sourceRow] = context2.Table.Row[destinationRow];

            AssertDataRowsAreCorrect(context.Table.Row[sourceRow], context2.Table.Row[destinationRow]);
        }

        private static void AssertDataRowsAreCorrect(DataRow<decimal> row1, DataRow<decimal> row2) =>
            Assert.IsTrue(Enumerable.SequenceEqual(row1, row2));

        private static void AssertTestDataCorrect(
            DataTable table, List<List<decimal>> testData)
        {
            for (int row = 0; row < testData.Count; row++)
            {
                for (int column = 0; column < testData[row].Count; column++)
                {
                    Assert.AreEqual(testData[row][column], table.Data[row, column]);
                }
            }
        }
    }
}
