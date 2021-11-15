using Noodles.Data.Projections;
using Noodles.Exceptions;

namespace Noodles.Data.Validations
{
    public class Validation_DecisionTree : Validation
    {
        public Validation_DecisionTree() : base(ValidationType.DecisionTree)
        {
        }

        protected override void Validate(DataTable dataTable)
        {
            if (Context == null) throw new NullValidationContextException(ValidationType.DecisionTree);
            if (Context.ValidationType != ValidationType.DecisionTree) throw new IncorrectValidationContextException(ValidationType.DecisionTree, Context.ValidationType);
        }
    }
}
