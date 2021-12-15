using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noodles.Data.Stores;
using Noodles.Test.Utilities;

namespace Noodles.Test.Data
{
    public enum DataColumnCreationMethod { FromCtorWithProjection, FromCtorWithDataStore, FromTable }
    [TestClass]
    public class When_DataColumn_Created
    {
        DataProvider _data;

        [TestInitialize]
        public void Initialize()
        {
            _data = new DataProvider();
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromTable)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IfColumnIndexIsNegative_ShouldThrowException(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy, DataColumnCreationMethod creationMethod)
        {
            _ = _data.GetDataColumnContext(dataStoreType, dataLoadStrategy, creationMethod, column: -1);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromTable)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IfColumnIndexIsTooHigh_ShouldThrowException(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy, DataColumnCreationMethod creationMethod)
        {
            _ = _data.GetDataColumnContext(dataStoreType, dataLoadStrategy, creationMethod, column: 101);
        }

        [DataTestMethod]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromCtorWithDataStore)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromCtorWithProjection)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.EnumOfEnum, DataColumnCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.Params, DataColumnCreationMethod.FromTable)]
        [DataRow(DataStoreType.SingleArray, DataLoadStrategy.RowByRow, DataColumnCreationMethod.FromTable)]
        public void Data_ShouldMatchColumnOfSource(DataStoreType dataStoreType, DataLoadStrategy dataLoadStrategy, DataColumnCreationMethod creationMethod)
        {
            DataColumnContext context = _data.GetDataColumnContext(dataStoreType, dataLoadStrategy, creationMethod);

            Assert.IsTrue(Enumerable.SequenceEqual(
                context.Context.TestData.Select(x => x[context.Index]), context.Column));
        }
    }
}
