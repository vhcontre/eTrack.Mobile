using System;
using System.Runtime.Serialization;

namespace eTrack.Mobile.Services.Exceptions
{
    [Serializable]
    internal class UserPermissionsException : Exception
    {
        public UserPermissionsException()
        {
        }

        public UserPermissionsException(string message) : base(message)
        {
        }

        public UserPermissionsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserPermissionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}