using System;
using System.Collections.Generic;
using Noodles.Data.Projections;

namespace Noodles.Data.Indexers
{
    public class DataRowIndexer<T> : IIndexer<T, DataRow<T>>
    {
        protected IDataStore<T> DataStore { get; private set; }

        public DataRowIndexer(DataTable<T> table) : this(table.Data) { }
        public DataRowIndexer(IDataStore<T> dataStore) => DataStore = dataStore;

        public DataRow<T> this[int index]
        {
            get => new DataRow<T>(DataStore, index);
            set
            {
                if (value.Data.ColumnCount != DataStore.ColumnCount) throw new IndexOutOfRangeException();
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
