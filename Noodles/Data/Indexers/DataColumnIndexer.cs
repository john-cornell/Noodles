using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;

namespace Noodles.Data.Indexers
{
    public class DataColumnIndexer<T> : IIndexer<T, IEnumerable<T>>
    {
        protected IDataStore<T> DataStore { get; private set; }

        public DataColumnIndexer(DataTable<T> table) : this(table.Data) { }
        public DataColumnIndexer(IDataStore<T> dataStore) => DataStore = dataStore;

        public IEnumerable<T> this[int index]
        {
            get => new DataColumn<T>(DataStore, index);
            set
            {
                int i = 0;

                if (DataStore.ColumnCount <= index) DataStore.ExpandToColumn(index, value.Count());

                IEnumerator<T> iterator = value.GetEnumerator();
                while (iterator.MoveNext())
                {
                    DataStore[i, index] = iterator.Current;

                    i++;
                }
            }
        }
    }
}
