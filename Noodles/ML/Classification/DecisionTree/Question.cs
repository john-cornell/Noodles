namespace Noodles.ML.Classification.DecisionTree
{
    public class Question
    {
        public enum QuestionType
        { None = 0, Continuous, Discrete, CategoricalNumeric, BooleanNumeric, Boolean, Labels }

        public Question()
        {
        }

        public Question NextNodeTrue { get; set; }
        public Question NextNodeFalse { get; set; }
    }
}