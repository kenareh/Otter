using System;

namespace Otter.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string FieldName { get; set; }
        public string Query { get; set; }

        public Type Type { get; set; }

        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}