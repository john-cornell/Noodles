using Noodles.Data.Projections;
using Noodles.Data.Validations;
using Noodles.Data.Validations.Context;

namespace Noodles.ML.Classification.DecisionTree
{
    public class DecisionTreeClassifier
    {
        private readonly Validator _validator = new Validator();
        private readonly DataTable _sourceData;
#pragma warning disable IDE0052 // Remove unread private members

        private readonly DataSliceTracker _rowTracker;
        private readonly DataSliceTracker _columnTracker;

#pragma warning restore IDE0052 // Remove unread private members

        public DecisionTreeClassifier(DataTable sourceData, int? labelIndex = null)
        {
            ValidateData(sourceData, labelIndex);

            _sourceData = sourceData;

            _rowTracker = new DataSliceTracker(_sourceData, DataSliceTracker.Slice.Row);
            _columnTracker = new DataSliceTracker(_sourceData, DataSliceTracker.Slice.Column);
        }

        private void ValidateData(DataTable sourceData, int? labelIndex = null)
        {
            _validator.Validate(sourceData, ValidationType.DecisionTree, new DecisionTreeValidationContext
            {
                OverrideLabelColumn = labelIndex
            });
        }
    }
}
