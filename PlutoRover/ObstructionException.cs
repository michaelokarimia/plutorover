using System;
using System.Runtime.Serialization;

namespace PlutoRover
{
    [Serializable]
    public class ObstructionException : Exception
    {
        public ObstructionException()
        {
        }

        public ObstructionException(string message) : base(message)
        {
        }

        public ObstructionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ObstructionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}