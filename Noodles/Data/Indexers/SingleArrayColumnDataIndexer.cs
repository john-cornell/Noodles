using System;
using System.Collections.Generic;
using System.Linq;

namespace Noodles.Data.Indexers
{
    public class SingleArrayColumnDataIndexer<T> : IIndexer<T, IEnumerable<T>>
    {
        IDataStore<T> _data;
        Func<int, T> _directDataAccessor;
        Action<int, T> _directDataMutator;

        public SingleArrayColumnDataIndexer(IDataStore<T> data, Func<int, T> directDataAccessor, Action<int, T> directDataMutator)
        {
            _data = data;
            _directDataAccessor = directDataAccessor;
            _directDataMutator = directDataMutator;
        }
        public IEnumerable<T> this[int index]
        {
            get
            {
                for (int i = 0; i < _data.RowCount; i++) { yield return _directDataAccessor((i * _data.ColumnCount) + index); }
            }
            set
            {
                for (int i = 0; i < _data.RowCount; i++) { _directDataMutator((i * _data.ColumnCount) + index, value.ElementAt(i)); }
            }
        }
    }
}
