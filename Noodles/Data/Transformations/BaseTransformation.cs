using System;

namespace Noodles.Data.Transformations
{
    public abstract class BaseTransformation<TInput, TOutput> 
    {
        public Type InputType { get => typeof(TInput); }
        public Type OutputType { get => typeof(TOutput); }
        public abstract TOutput Transform(TInput input);

        public TOutput ObjectTransform(object input) => Transform((TInput)Convert.ChangeType(input, InputType));
    }
}
