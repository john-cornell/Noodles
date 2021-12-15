using Noodles.ML.Classification.DecisionTree.QuestionGenerators;
using System;
using System.Collections.Generic;
using static Noodles.ML.Classification.DecisionTree.Question;

namespace Noodles.ML.Classification.DecisionTree
{
    public class DecisionGenerator
    {
        private Dictionary<QuestionType, QuestionGenerator> _questionGenerators;

        public enum ProcessState
        { Pending, Running, Complete, Error };

        public DecisionGenerator()
        {
            State = ProcessState.Pending;

            LoadQuestionGenerators();
        }

        public void Generate(DecisionGeneratorContext context)
        {
            State = ProcessState.Running;

            GenerateQuestion(context);

            State = ProcessState.Complete;
        }

        public void GenerateQuestion(DecisionGeneratorContext context)
        {
            try
            {
                List<Question> questions = new List<Question>();

                foreach (int columnIndex in context.ColumnTracker)
                {
                    questions.Add()
                }
            }
            catch (Exception ex)
            {
                Exception = ex;
                State = ProcessState.Error;
            }
        }

        private void LoadQuestionGenerators()
        {
            throw new NotImplementedException();
        }

        private void LoadQuestionGenerator<T>() where T : QuestionGenerator
        {
            T item = Activator.CreateInstance<T>();

            _questionGenerators[item.Type] = item;
        }

        public ProcessState State { get; set; }
        public Question TopNode { get; set; }
        public Exception Exception { get; private set; }
    }
}