using System;

namespace Noodles.Exceptions
{

    [Serializable]
    public class InconsistentRowLengthException : NoodlesException
    {
        public InconsistentRowLengthException() { }
        public InconsistentRowLengthException(string message) : base(message) { }
        public InconsistentRowLengthException(string message, Exception inner) : base(message, inner) { }
        protected InconsistentRowLengthException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
