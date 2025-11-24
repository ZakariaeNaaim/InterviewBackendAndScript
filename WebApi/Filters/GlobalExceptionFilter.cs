using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using App.WebApi.Wrappers;
using Application.Exceptions;
using Serilog;
using WebApi.Models;

namespace WebApi.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var ex = context.Exception;
            var traceId = Guid.NewGuid().ToString(); // TODO: replace by correlation ID

            Log.Error(ex, "Unhandled exception. TraceId={TraceId}", traceId);

            var error = new ApiErrorResponse
            {
                TraceId = traceId
            };

            HttpStatusCode status;
            string codErreur;
            string libErreur;

            switch (ex)
            {
                case ValidationException vex:
                    status = HttpStatusCode.BadRequest;
                    codErreur = "VALIDATION_ERROR";
                    libErreur = "Validation error";
                    error.Code = codErreur;
                    error.Message = vex.Message;
                    error.Details = vex.SourceName;
                    break;

                case BusinessRuleException brex:
                    status = HttpStatusCode.BadRequest;
                    codErreur = brex.Code ?? "BUSINESS_RULE_ERROR";
                    libErreur = "Business rule violation";
                    error.Code = codErreur;
                    error.Message = brex.Message;
                    break;

                case NotFoundException nfex:
                    status = HttpStatusCode.NotFound;
                    codErreur = "NOT_FOUND_ERROR";
                    libErreur = "Resource not found";
                    error.Code = codErreur;
                    error.Message = nfex.Message;
                    error.Details = new { nfex.EntityName, nfex.Key };
                    break;

                default:
                    status = HttpStatusCode.InternalServerError;
                    codErreur = "UNEXPECTED_ERROR";
                    libErreur = "Unexpected error";
                    error.Code = codErreur;
                    error.Message = "An unexpected error occurred.";
                    break;
            }

            // TODO: log ex + traceId here

            var appResult = new AppResult<ApiErrorResponse>
            {
                IsSuccess = false,
                CodErreur = codErreur,
                LibErreur = libErreur,
                Message = error.Message,
                Data = error,
                Status = status,
                Timestamp = DateTime.UtcNow
            };

            context.Response = context.Request.CreateResponse(status, appResult);
        }
    }
}
