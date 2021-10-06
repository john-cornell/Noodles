using System;

namespace Noodles.Exceptions
{

    [Serializable]
    public class IncorrectRowLengthException : NoodlesException
    {
        public IncorrectRowLengthException() { }

        public IncorrectRowLengthException(int rowLengthProvided, int expectedRowLength) : this($"DataTable expected data with row length {expectedRowLength}, however data passed with row length {rowLengthProvided}") { }

        public IncorrectRowLengthException(string message) : base(message) { }
        public IncorrectRowLengthException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectRowLengthException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
