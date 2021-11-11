using System;

namespace Noodles.Exceptions
{

    [Serializable]
    public class IncorrectHeaderLengthException : NoodlesException
    {
        public IncorrectHeaderLengthException() { }
        public IncorrectHeaderLengthException(string message) : base(message) { }
        public IncorrectHeaderLengthException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectHeaderLengthException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
