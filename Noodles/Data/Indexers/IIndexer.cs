namespace Noodles.Data.Indexers
{
    public interface IIndexer<T, TReturn>
    {
        TReturn this[int index] { get; set; }
    }
}
