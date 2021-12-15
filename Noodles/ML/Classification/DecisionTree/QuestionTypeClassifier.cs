using Noodles.Test.ExtensionTests;
using System;
using System.Collections.Generic;
using System.Linq;
using static Noodles.ML.Classification.DecisionTree.Question;

namespace Noodles.ML.Classification.DecisionTree
{
    public class QuestionTypeClassifier
    {
        public QuestionType ClassifyColumn(IEnumerable<object> columnData, QuestionType hint = QuestionType.None, int discreteCountThreshold = 10)
        {
            object template = columnData.First();

            if (template.GetType() == typeof(string)) return QuestionType.Labels;
            else if (template.IsNumber())
            {
                if (
                    (hint == QuestionType.None || hint == QuestionType.BooleanNumeric) &&
                    Enumerable.SequenceEqual(columnData.Select(d => d.ConvertType<int>()).Distinct().OrderBy(a => a), new int[] { 0, 1 }))
                {
                    return QuestionType.BooleanNumeric;
                }
                else if (hint == QuestionType.CategoricalNumeric)
                {
                    return QuestionType.CategoricalNumeric;
                }
                else if (
                    hint == QuestionType.Discrete ||
                    (template is Int32 || template is long) &&
                    columnData.Distinct().Count() <= discreteCountThreshold
                    )
                {
                    return QuestionType.Discrete;
                }
                else
                {
                    return QuestionType.Continuous;
                }
            }
            else if (template is bool)
            {
                return QuestionType.Boolean;
            }
            else
                return QuestionType.None;
        }
    }
}