using Noodles.Data.Projections;
using Noodles.Data.Validations.Context;

namespace Noodles.Data.Validations
{
    public abstract class Validation
    {
        protected ValidationContext Context;

        public Validation(ValidationType valdationType)
        {
            ValidationType = valdationType;
        }

        public ValidationType ValidationType { get; private set; }

        public void Validate(DataTable dataTable, ValidationContext context)
        {
            Context = context;
        }

        protected abstract void Validate(DataTable dataTable);
    }
}
