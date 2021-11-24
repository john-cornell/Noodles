namespace Noodles.Data.Validations.Context
{
    public class DecisionTreeValidationContext : ValidationContext
    {
        public DecisionTreeValidationContext() : base(ValidationType.DecisionTree)
        {
            OverrideLabelColumn = null;
        }

        public int? OverrideLabelColumn { get; set; }
    }
}
