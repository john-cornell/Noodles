using System;

namespace Noodles.Exceptions
{

    [Serializable]
    public class UnableToClassifyDataException : NoodlesException
    {
        public UnableToClassifyDataException() { }
        public UnableToClassifyDataException(string message) : base(message) { }
        public UnableToClassifyDataException(string message, Exception inner) : base(message, inner) { }
        protected UnableToClassifyDataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
