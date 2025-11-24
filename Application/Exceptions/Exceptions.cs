using System;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public string SourceName { get; }

        public ValidationException(string sourceName, string message)
            : base(message)
        {
            SourceName = sourceName;
        }
    }


    public class NotFoundException : Exception
    {
        public string EntityName { get; }
        public object Key { get; }

        public NotFoundException(string entityName, object key)
            : base($"{entityName} with key '{key}' was not found.")
        {
            EntityName = entityName;
            Key = key;
        }
    }
    public class BusinessRuleException : Exception
    {
        public string Code { get; }

        public BusinessRuleException(string code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
