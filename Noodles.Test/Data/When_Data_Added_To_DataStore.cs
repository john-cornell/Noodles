using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Projections;
using Noodles.Data.Stores;
using Noodles.Test.Utilities;

namespace Noodles.Test.Data
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
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
        public void Column_Data_Should_Be_Correct(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            Assert.AreEqual(context.TestData.First().Count, context.Table.ColumnCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
        public void Row_Data_Should_Be_Correct(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);

            Assert.AreEqual(context.TestData.Count, context.Table.RowCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
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
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows, false, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns, false, true)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Testing exception")]
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
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows, false, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns, true, true)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns, true, false)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns, false, true)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "Testing Exception")]
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
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
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
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
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
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
        public void ShouldCorrectlyUpdate_When_DataColumnInserted(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, dataLoadStrategy);
            int sourceColumn = _random.GetRandomInt(0, context.Table.ColumnCount);
            int destinationColumn;
            do
            {
                destinationColumn = _random.GetRandomInt(0, context.Table.ColumnCount);
            }
            while (sourceColumn == destinationColumn);

            context.Table.Column[sourceColumn] = context.Table.Column[destinationColumn];


            AssertDataColumnsAreCorrect(context.Table.Column[sourceColumn], context.Table.Column[destinationColumn]);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
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

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataRows)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.ByDataColumns)]
        public void Should_Grow_With_Data(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy)
        {
            List<List<decimal>> testData = _data.GetTableListData(10, 1000);

            DataTable<decimal> table = new DataTable<decimal>(
                columnCount: 10,
                initialRowCount: 3,
                dataStoreType: dataStoreType);

            testData = _data.LoadData(table, testData, dataLoadStrategy);

            AssertTestDataCorrect(table, testData);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_Grow_With_Data_And_Insert_Next_Row_When_Column_Insert_Initiated_Growth(DataStoreType dataStoreType)
        {
            DataTable<decimal> table = new DataTable<decimal>(100, dataStoreType: dataStoreType);
            List<List<decimal>> data = _data.GetTableListData(100, 1);

            table.Column[0] = data[0];

            Assert.AreEqual(100, table.ColumnCount);
            Assert.AreEqual(100, table.RowCount);

            List<decimal> row = Enumerable.Range(0, 100).Select(i => i == 0 ? 11m : 0m).ToList();

            table.Add(row);
            Assert.AreEqual(table.Data[100, 0], 11m);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_Grow_Row_Size_When_Columns_Added(DataStoreType dataStoreType)
        {
            TestDataContext context = _data.GetTestDataContext(dataStoreType, DataLoadStrategy.ByDataColumns);
            Assert.AreEqual(context.TestData.Count, context.Table.RowCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_when_loaded_from_url(DataStoreType dataStoreType)
        {
            new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_when_loaded_from_url_numeric(DataStoreType dataStoreType)
        {
            new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_not_fail_when_loaded_from_url_object(DataStoreType dataStoreType)
        {
            new DataTable(DataFileProvider.DiabetesCsv, firstRowIsHeader: true, dataStoreType: dataStoreType, testForNumeric: false);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_report_all_as_double_when_numeric(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(DataFileProvider.DiabetesCsv, dataStoreType: dataStoreType);

            List<Type> types = table.Rows().SelectMany(r => r).Select(r => r.GetType()).Distinct().ToList();

            Assert.AreEqual(1, types.Count());
            Assert.AreEqual(typeof(double), types[0]);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_store_data_properly_when_added_by_row(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<int> column0 = Enumerable.Range(0, 100).ToList();
            List<int> column1 = Enumerable.Range(0, 100).Select(i => i * 10).ToList();
            List<string> column2 = _random.GetRandomWords(100).ToList();
            List<int> column3 = _random.GetRandomInts(100).ToList();
            List<decimal> column4 = _random.GetRandomDecimals(100).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0], column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1], column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2], column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3], column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4], column4.Cast<object>()));
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void Should_store_data_properly_when_added_by_row_staggered_size(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            List<int> column0 = Enumerable.Range(0, 100).ToList();
            List<int> column1 = Enumerable.Range(0, 2243).Select(i => i * 10).ToList();
            List<string> column2 = _random.GetRandomWords(51233).ToList();
            List<int> column3 = _random.GetRandomInts(432).ToList();
            List<decimal> column4 = _random.GetRandomDecimals(321).ToList();

            table.Column[0] = column0.Cast<object>();
            table.Column[1] = column1.Cast<object>();
            table.Column[2] = column2.Cast<object>();
            table.Column[3] = column3.Cast<object>();
            table.Column[4] = column4.Cast<object>();

            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[0].Take(column0.Count), column0.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[1].Take(column1.Count), column1.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[2].Take(column2.Count), column2.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[3].Take(column3.Count), column3.Cast<object>()));
            Assert.IsTrue(Enumerable.SequenceEqual(table.Column[4].Take(column4.Count), column4.Cast<object>()));
        }

        private static void AssertDataRowsAreCorrect(IEnumerable<decimal> row1, IEnumerable<decimal> row2) =>
            Assert.IsTrue(Enumerable.SequenceEqual(row1, row2));

        private static void AssertDataColumnsAreCorrect(IEnumerable<decimal> col1, IEnumerable<decimal> col2) =>
            Assert.IsTrue(Enumerable.SequenceEqual(col1, col2));

        private static void AssertTestDataCorrect(
            DataTable<decimal> table, List<List<decimal>> testData)
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
