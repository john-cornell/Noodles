using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Indexers;
using Noodles.Data.Stores;
using Noodles.Exceptions;

namespace Noodles.Data.Projections
{
    public class DataTable : DataTable<object>
    {
        public DataTable() : this(0)
        {
            Row = new DataRowIndexer<object>(Data);
        }

        public DataTable(
            int columnCount,
            int initialRowCount = 1000,
            IEnumerable<string> headers = null,
            DataStoreType dataStoreType = DataStoreType.SingleArray) : base(columnCount, initialRowCount, headers: headers, dataStoreType: dataStoreType)
        {

        }

        public DataTable(string url, bool firstRowIsHeader = true, DataStoreType dataStoreType = DataStoreType.SingleArray, bool testForNumeric = true) : base(0, dataStoreType: dataStoreType)
        {
            DataTableUrlLoader.LoadData(this, url, firstRowIsHeader, testForNumeric);
        }

        public DataTable(IDataStore<object> data) : base(data) { }

        public IEnumerable<T> GetColumn<T>(int index) => Column[index].Cast<T>();
        public IEnumerable<T> GetRow<T>(int index) => Row[index].Cast<T>();

        public IEnumerable<IEnumerable<object>> Rows() => Rows<object>();
        public IEnumerable<IEnumerable<object>> Columns() => Rows<object>();

        public IEnumerable<IEnumerable<T>> Rows<T>()
        {
            for (int i = 0; i < RowCount; i++) yield return GetRow<T>(i).Select(datum => datum);
        }

        public IEnumerable<IEnumerable<T>> Columns<T>()
        {
            for (int i = 0; i < RowCount; i++) yield return GetColumn<T>(i);
        }

        public bool IsColumnUniqueType(int index) => Column[index].Select(d => d.GetType()).Distinct().Count() == 1;
    }

    public class DataTable<T> : Projection<T>
    {
        public List<string> Headers { get; set; }

        public DataTable() : this(0)
        {

        }

        public DataTable(
            int columnCount,
            int initialRowCount = 1000,
            IEnumerable<string> headers = null,
            DataStoreType dataStoreType = DataStoreType.SingleArray) : base(columnCount, initialRowCount, dataStoreType, headers: headers)
        {
            Column = new DataColumnIndexer<T>(Data);
            Row = new DataRowIndexer<T>(Data);
            Headers = headers?.ToList();
        }

        public DataTable(IDataStore<T> data, DataStoreType dataStoreType = DataStoreType.SingleArray) : base(data)
        {
            Column = new DataColumnIndexer<T>(Data);
            Row = new DataRowIndexer<T>(Data);
        }

        public void Add(IEnumerable<IEnumerable<T>> data)
        {
            if (!data.Any()) return;

            AssertConsistentRowLength(data);
            AssertColumnCount(data.First());

            Data.Add(data);
        }

        public void Add(IEnumerable<T> row)
        {
            AssertColumnCount(row);

            Data.Add(row);
        }

        public void Add(params IEnumerable<T>[] data)
        {
            Data.Add(data);
        }

        public IIndexer<T, IEnumerable<T>> Column { get; protected set; }
        public IIndexer<T, IEnumerable<T>> Row { get; protected set; }

        public DataColumn<T> GetDataColumn(int columnIndex) => new DataColumn<T>(Data, columnIndex);
        public DataRow<T> GetDataRow(int rowIndex) => new DataRow<T>(Data, rowIndex);

        private void AssertColumnCount(IEnumerable<T> row)
        {
            if (Data.ColumnCount > 0 && row.Count() != Data.ColumnCount) throw new IncorrectRowLengthException(row.Count(), Data.ColumnCount);
        }

        private static void AssertConsistentRowLength(IEnumerable<IEnumerable<T>> data)
        {
            if (data.Select(d => d.Count()).Distinct().Count() > 1) throw new InconsistentRowLengthException();
        }

        public int ColumnCount { get => Data.ColumnCount; set => Data.ColumnCount = value; }
        public int RowCount { get => Data.RowCount; }
    }
}
