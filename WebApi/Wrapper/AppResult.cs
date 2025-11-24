using System.Net;
using System;namespace App.WebApi.Wrappers
{
    public class AppResult<T>
    {
        public bool IsSuccess { get; set; }
        public string CodErreur { get; set; }
        public string LibErreur { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpStatusCode Status { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public static AppResult<T> Ok(T data) =>
            new AppResult<T> { IsSuccess = true, Data = data, Status = HttpStatusCode.OK };

        public static AppResult<T> Created(T data) =>
            new AppResult<T> { IsSuccess = true, Data = data, Status = HttpStatusCode.Created };

        public static AppResult<T> BadRequest(string message) =>
            new AppResult<T> { IsSuccess = false, CodErreur = "400", LibErreur = "Bad Request", Message = message, Status = HttpStatusCode.BadRequest };

        public static AppResult<T> NotFound(string message = null) =>
            new AppResult<T> { IsSuccess = false, CodErreur = "404", LibErreur = "Not Found", Message = message, Status = HttpStatusCode.NotFound };

        public static AppResult<T> Error(string codErreur, string libErreur, Exception ex = null) =>
            new AppResult<T>
            {
                IsSuccess = false,
                CodErreur = codErreur,
                LibErreur = libErreur,
                Message = ex?.Message,
                Status = HttpStatusCode.InternalServerError
            };
    }
}