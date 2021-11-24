using Noodles.Exceptions;

namespace Noodles.Data.Transformations
{
    public class NumericToBooleanTransformer : BaseTransformation<int, bool>
    {
        public override bool Transform(int input)
        {
            if (input != 0 && input != 1) throw new TransformationException($"Invalid input: {input}, expecting 0 or 1");

            return input == 1;
        }
    }
}
