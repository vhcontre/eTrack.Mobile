using System;
using System.Runtime.Serialization;

namespace eTrack.Mobile.Services.Exceptions
{
    public class UserCredentialsException : Exception
    {
        public UserCredentialsException()
        {
        }

        public UserCredentialsException(string message) : base(message)
        {
        }

        public UserCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
