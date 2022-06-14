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

        public EntityNotFoundException(string fieldName, string query, Type type)
        {
            FieldName = fieldName;
            Query = query;
            Type = type;
        }

        public override string ToString()
        {
            return $"Can not find entity {Type.Name} with field {FieldName} and value {Query}";
        }
    }
}