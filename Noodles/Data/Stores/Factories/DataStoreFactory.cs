using System;

namespace Noodles.Data.Stores.Factories
{
    public static class DataStoreFactory<T>
    {
        public static IDataStore<T> CreateDataStore(DataStoreType dataStoreType, int initialRowCount, int columnCount)
        {
            switch (dataStoreType)
            {
                case DataStoreType.SingleArray:
                    return new SingleArrayDataStore<T>(columnCount, initialRowCount);
                case DataStoreType.MultiDimArray:
                    break;
                case DataStoreType.SingleArrayPages:
                    break;
                case DataStoreType.MultiDimArrayPages:
                    break;
                case DataStoreType.ListOfArrays:
                    break;
                case DataStoreType.ListOfLists:
                    break;
                default:
                    throw new NotImplementedException($"Unknown Data Store Type '{dataStoreType}'");
            }

            throw new NotImplementedException($"Data Store Type '{dataStoreType}' factory not yet implemented");
        }
    }
}
