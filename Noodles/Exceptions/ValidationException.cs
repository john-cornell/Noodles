using System;
using Noodles.Data.Validations;

namespace Noodles.Exceptions
{

    public class ValidationException : NoodlesException
    {
        public ValidationType ValidationType { get; private set; }
        public ValidationException(ValidationType validationType) : this("Data Validation Failed", validationType) { }
        public ValidationException(string message, ValidationType validationType) : this(message, null, validationType) { }
        public ValidationException(string message, Exception inner, ValidationType validationType) : base(message, inner) { ValidationType = validationType; }
        protected ValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
