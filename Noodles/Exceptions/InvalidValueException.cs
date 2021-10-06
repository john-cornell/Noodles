﻿using System;

namespace Noodles.Exceptions
{

    [Serializable]
    public class InvalidValueException : NoodlesException
    {
        public InvalidValueException() { }
        public InvalidValueException(string message) : base(message) { }
        public InvalidValueException(string message, Exception inner) : base(message, inner) { }
        protected InvalidValueException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
