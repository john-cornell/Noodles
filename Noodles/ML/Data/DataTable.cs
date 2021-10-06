using Noodles.ML.Data.Stores;

namespace Noodles.ML.Data
{
    public class DataTable : DataTable<decimal>
    {
        public DataTable() : this(0)
        {

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
        int _columnCount;

        public DataTable() : this(0)
        {

        }

        public DataTable(
            int columnCount,
            int initialRowCount = 1000,
            DataStoreType dataStoreType = DataStoreType.SingleArray) : base(columnCount, initialRowCount, dataStoreType)
        {

        }

        public DataTable(IDataStore<T> data) : base(data) { }

        public int ColumnCount { get => Data.ColumnCount; set => Data.ColumnCount = value; }
        public int RowCount { get => Data.RowCount; }
    }
}
