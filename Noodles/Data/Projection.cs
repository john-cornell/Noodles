using System.Collections.Generic;
using System.Linq;
using Noodles.Data.Stores;
using Noodles.Data.Stores.Factories;
using Noodles.Exceptions;

namespace Noodles.Data
{
    public abstract class Projection<T>
    {
        public string[] Headers { get; set; }

        public IDataStore<T> Data { get; private set; }

        public Projection(IDataStore<T> data, IEnumerable<string> headers = null)
        {
            SetDataAndHeaders(data, headers);
        }


        public Projection(int columnCount, int initialRowCount, DataStoreType dataStoreType, IEnumerable<string> headers = null)
        {
            SetDataAndHeaders(DataStoreFactory<T>.CreateDataStore(dataStoreType, initialRowCount, columnCount), headers);
        }

        private void SetDataAndHeaders(IDataStore<T> data, IEnumerable<string> headers)
        {
            Data = data;

            Headers = new string[Data.ColumnCount];

            if (headers != null)
            {
                if (headers.Count() != Data.ColumnCount) throw new IncorrectHeaderLengthException();

                int i = 0;

                IEnumerator<string> iterator = headers.GetEnumerator();
                while (iterator.MoveNext())
                {
                    Headers[i] = iterator.Current;

                    i++;
                }
            }
        }
    }
}
