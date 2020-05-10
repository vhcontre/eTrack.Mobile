using System;
using System.Runtime.Serialization;

namespace eTrack.Mobile.Services.Exceptions
{
    public class NetworkAccessException : Exception
    {
        public NetworkAccessException()
        {
        }

        public NetworkAccessException(string message) : base(message)
        {
        }

        public NetworkAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NetworkAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}