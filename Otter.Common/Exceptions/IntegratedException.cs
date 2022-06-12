using System;

namespace Otter.Common.Exceptions
{
    public class IntegratedException : Exception
    {
        public string ServiceName { get; protected set; }

        public IntegratedException()
        {
        }

        public IntegratedException(string message, string serviceName) : base(message)
        {
            this.ServiceName = serviceName;
        }

        public override string ToString()
        {
            return $"Can not to integrate to {ServiceName}.";
        }
    }
}