namespace Noodles.Data.Indexers
{
    public interface INamedIndexer<T, TReturn> : IIndexer<T, TReturn>
    {
        TReturn this[string name] { get; set; }
    }
}
