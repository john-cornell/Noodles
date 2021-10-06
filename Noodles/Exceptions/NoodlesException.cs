using System;
using System.Collections.Generic;
using System.Text;

namespace Noodles.Exceptions
{

    [Serializable]
    public class NoodlesException : Exception
    {
        public NoodlesException() { }
        public NoodlesException(string message) : base(message) { }
        public NoodlesException(string message, Exception inner) : base(message, inner) { }
        protected NoodlesException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
