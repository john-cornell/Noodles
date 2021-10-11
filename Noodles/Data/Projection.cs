using System.Collections.Generic;
using Noodles.Data.Stores;
using Noodles.Data.Stores.Factories;

namespace Noodles.Data
{
    public abstract class Projection<T>
    {
        List<string[]> _headers;
        public IDataStore<T> Data { get; private set; }

        public Projection(IDataStore<T> data)
        {
            Data = data;
        }

        public Projection(int columnCount, int initialRowCount, DataStoreType dataStoreType)
        {
            Data = DataStoreFactory<T>.CreateDataStore(dataStoreType, initialRowCount, columnCount);
        }
    }
}
