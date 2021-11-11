using System;
using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;

namespace Noodles.Data.Indexers
{
    public class DataRowIndexer<T> : IIndexer<T, IEnumerable<T>>
    {
        protected IDataStore<T> DataStore { get; private set; }

        public DataRowIndexer(DataTable<T> table) : this(table.Data) { }
        public DataRowIndexer(IDataStore<T> dataStore) => DataStore = dataStore;

        public IEnumerable<T> this[int index]
        {
            get => DataStore.Row[index];
            set
            {
                if (value.Count() != DataStore.ColumnCount) throw new IndexOutOfRangeException();
                int i = 0;

                IEnumerator<T> iterator = value.GetEnumerator();
                while (iterator.MoveNext())
                {
                    DataStore[index, i] = iterator.Current;

                    i++;
                }
            }

        }

    }
}
