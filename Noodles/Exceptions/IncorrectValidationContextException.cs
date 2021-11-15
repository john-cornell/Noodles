using System;
using Noodles.Data.Validations;

namespace Noodles.Exceptions
{

    [Serializable]
    public class IncorrectValidationContextException : NoodlesException
    {
        public ValidationType ExpectedValidationType { get; set; }
        public ValidationType ReceivedValidationType { get; set; }

        public IncorrectValidationContextException(ValidationType expectedValidationType, ValidationType receivedValidationType) { }
        public IncorrectValidationContextException(ValidationType expectedValidationType, ValidationType receivedValidationType, string message) : base(message) { }
        public IncorrectValidationContextException(ValidationType expectedValidationType, ValidationType receivedValidationType, string message, Exception inner) : base(message, inner) { }
        protected IncorrectValidationContextException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
