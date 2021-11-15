using System;
using Noodles.Data.Validations;

namespace Noodles.Exceptions
{

    [Serializable]
    public class NullValidationContextException : NoodlesException
    {
        public ValidationType ExpectedValidationType { get; set; }

        public NullValidationContextException(ValidationType expectedValidationType) : this(expectedValidationType, "No validation context was given for a validation routine that requires it.") { }
        public NullValidationContextException(ValidationType expectedValidationType, string message) : base(message) { ExpectedValidationType = expectedValidationType; }
        public NullValidationContextException(ValidationType expectedValidationType, string message, Exception inner) : base(message, inner) { ExpectedValidationType = expectedValidationType; }
        protected NullValidationContextException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
