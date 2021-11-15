namespace Noodles.Data.Validations.Context
{
    public abstract class ValidationContext
    {
        public ValidationType ValidationType { get; set; }

        public ValidationContext(ValidationType validationType)
        {
            ValidationType = validationType;
        }
    }
}
