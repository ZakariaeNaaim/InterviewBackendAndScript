using System.Collections.Generic;

namespace WebApi.Models
{
    public class ApiErrorResponse
    {
        public string TraceId { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public object Details { get; set; }
        public IEnumerable<FieldError> Errors { get; set; }
    }

    public class FieldError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
