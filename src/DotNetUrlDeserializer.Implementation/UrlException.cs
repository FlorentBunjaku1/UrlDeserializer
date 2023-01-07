using System;

namespace DotNetUrlDeserializer.Implementation
{
    public class UrlException : AggregateException
    {
        private const string ExceptionMessageTemplate = "Url Encoded data was malformed there fore deserializer produced a malformed JSON string: {0}";
        
        public UrlException(string message, Exception innerException) : base(string.Format(ExceptionMessageTemplate, message), innerException)
        {
        }
    }
}
