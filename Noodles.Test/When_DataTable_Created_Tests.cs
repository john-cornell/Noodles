using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Exceptions;
using Noodles.ML.Data;
using Noodles.ML.Data.Stores;

namespace Noodles.Test
{
    [TestClass]
    public class When_DataTable_Created_Tests
    {
        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void ShouldHaveColumnCount_Zero(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            Assert.AreEqual(0, table.ColumnCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void ShouldHaveRowCount_Zero(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            Assert.AreEqual(0, table.RowCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void AndColumnCountUpdatedThroughProperty_ShouldBeSet(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            table.ColumnCount = 10;
            Assert.AreEqual(10, table.ColumnCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(InvalidValueException))]
        public void AndColumnCountSetThroughCtor_Negative_ShouldThrowException(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(-2, dataStoreType: dataStoreType);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void AndColumnCountSetThroughCtor_Zero_ShouldBeChangable(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            Assert.AreEqual(0, table.ColumnCount);

            table.ColumnCount = 10;

            Assert.AreEqual(10, table.ColumnCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void AndColumnCountSetThroughCtor_ShouldBeSet(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(10, dataStoreType: dataStoreType);

            Assert.AreEqual(10, table.ColumnCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(ImmutabilityException))]
        public void AndColumnCountSetThroughCtor_ShouldNotBeChangable(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(14, dataStoreType: dataStoreType);

            table.ColumnCount = 10;
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(ImmutabilityException))]
        public void AndColumnCountSetThroughProperty_ShouldNotAllowChange(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            table.ColumnCount = 10;
            table.ColumnCount = 12;
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        public void AndColumnCountSetThroughProperty_ToZero_ShouldBeChangable(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            table.ColumnCount = 10;

            Assert.AreEqual(10, table.ColumnCount);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray)]
        [ExpectedException(typeof(InvalidValueException))]
        public void AndColumnCountSetThroughProperty_ToNegative_ShouldThrowException(DataStoreType dataStoreType)
        {
            DataTable table = new DataTable(0, dataStoreType: dataStoreType);

            table.ColumnCount = -10;
        }

    }
}
