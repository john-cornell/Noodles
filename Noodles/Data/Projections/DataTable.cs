using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Indexers;
using Noodles.Data.Stores;
using Noodles.Exceptions;

namespace Noodles.Data.Projections
{
    public class DataTable : DataTable<decimal>
    {
        public DataTable() : this(0)
        {
            Row = new DataRowIndexer<decimal>(Data);
        }

        public DataTable(
            int columnCount,
            int initialRowCount = 1000,
            DataStoreType dataStoreType = DataStoreType.SingleArray) : base(columnCount, initialRowCount, dataStoreType)
        {

        }

        public DataTable(IDataStore<decimal> data) : base(data) { }
    }

    public class DataTable<T> : Projection<T>
    {
        public DataTable() : this(0)
        {

        }

        public DataTable(
            int columnCount,
            int initialRowCount = 1000,
            DataStoreType dataStoreType = DataStoreType.SingleArray) : base(columnCount, initialRowCount, dataStoreType)
        {
            Row = new DataRowIndexer<T>(Data);
        }

        public DataTable(IDataStore<T> data) : base(data)
        {
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

        public IIndexer<T, DataRow<T>> Row { get; protected set; }

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
