namespace Noodles.Data.Transformations
{
    public abstract class BaseTransformation<TInput, TOutput>
    {
        public abstract TOutput Convert(TInput input);
    }
}
