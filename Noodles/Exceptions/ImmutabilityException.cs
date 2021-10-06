namespace Noodles.Exceptions
{

    [System.Serializable]
    public class ImmutabilityException : NoodlesException
    {
        public ImmutabilityException() { }
        public ImmutabilityException(string message) : base(message) { }
        public ImmutabilityException(string message, System.Exception inner) : base(message, inner) { }
        protected ImmutabilityException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
