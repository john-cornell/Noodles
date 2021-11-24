using System;
using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Projections;

namespace Noodles.Data.Indexers
{
    public class DataColumnIndexer<T> : INamedIndexer<T, IEnumerable<T>>
    {
        readonly Func<string, int> _columnIndexer;
        readonly Action<string> _headerAppender;

        protected IDataStore<T> DataStore { get; private set; }

        public IEnumerable<T> this[string name]
        {
            get => this[_columnIndexer(name)];
            set
            {
                int index = _columnIndexer(name);
                if (index != -1) this[index] = value;
                else
                {
                    this[DataStore.ColumnCount] = value;
                    _headerAppender(name);
                }
            }
        }

        public DataColumnIndexer(IDataStore<T> dataStore, Func<string, int> columnIndexer, Action<string> headerAppender)
        {
            DataStore = dataStore;
            _columnIndexer = columnIndexer;
            _headerAppender = headerAppender;
        }

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
