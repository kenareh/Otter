using System;
using System.Runtime.Serialization;
using Otter.Common.Enums;

namespace Otter.Common.Exceptions
{
    public class BusinessViolatedException : Exception
    {
        public BusinessRule BusinessRule { get; protected set; }
        public ApiResultStatusCode ApiResultStatusCode { get; set; }

        public BusinessViolatedException()
        {
        }

        public BusinessViolatedException(string message, BusinessRule businessRule) : base(message)
        {
            this.BusinessRule = businessRule;
        }

        public BusinessViolatedException(string message, ApiResultStatusCode apiResultStatusCode) : base(message)
        {
            ApiResultStatusCode = apiResultStatusCode;
        }

        public BusinessViolatedException(string message) : base(message)
        {
        }

        public BusinessViolatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessViolatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}