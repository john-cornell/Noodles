using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Stores;
using Noodles.Test.Utilities;

namespace Noodles.Test.Data
{
    public enum DataRowCreationMethod { FromCtorWithProjection, FromCtorWithDataStore, FromTable }

    [TestClass]
    public class When_DataRow_Created
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
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromTable)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IfRowIndexIsNegative_ShouldThrowException(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy, DataRowCreationMethod creationMethod)
        {
            DataRowContext context = _data.GetDataRowContext(dataStoreType, dataLoadStrategy, creationMethod, row: -1);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromTable)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IfRowIndexIsTooHigh_ShouldThrowException(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy, DataRowCreationMethod creationMethod)
        {
            DataRowContext context = _data.GetDataRowContext(dataStoreType, dataLoadStrategy, creationMethod, row: 101);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataRowCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataRowCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataRowCreationMethod.FromTable)]
        public void Data_ShouldMatchRowOfSource(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy, DataRowCreationMethod creationMethod)
        {
            DataRowContext context = _data.GetDataRowContext(dataStoreType, dataLoadStrategy, creationMethod);
            Assert.IsTrue(Enumerable.SequenceEqual(context.Context.TestData[context.Index], context.Row));
        }
    }
}
