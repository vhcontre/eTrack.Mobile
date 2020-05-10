using System;
using System.Runtime.Serialization;

namespace eTrack.Mobile.Services.Exceptions
{
    public class RepositoryException : Exception { }
    public class DataOperationException : Exception { }

    public class AccessDeniedException : Exception
    {
        public AccessDeniedException()
        {
        }

        public AccessDeniedException(string message) : base(message)
        {
        }

        public AccessDeniedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
