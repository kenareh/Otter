using Otter.Common.Enums;
using System;

namespace Otter.Common.Exceptions
{
    public class IntegratedException : Exception
    {
        public ApiResultStatusCode ApiResultStatusCode { get; set; }

        public IntegratedException(string message, ApiResultStatusCode apiResultStatusCode) : base(message)
        {
            ApiResultStatusCode = apiResultStatusCode;
        }
    }
}