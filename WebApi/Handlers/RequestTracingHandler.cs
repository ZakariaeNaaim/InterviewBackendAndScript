using Serilog;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Handlers
{
    public class RequestTracingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var traceId = Guid.NewGuid().ToString(); // Correlation Id
            var method = request.Method.Method;
            var path = request.RequestUri.PathAndQuery;

            var sw = Stopwatch.StartNew();

            Log.Information("Starting request {Method} {Path} TraceId={TraceId}", method, path, traceId);

            HttpResponseMessage response;

            try
            {
                response = await base.SendAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                sw.Stop();
                Log.Error(ex,
                    "Unhandled exception during request {Method} {Path} TraceId={TraceId} DurationMs={Duration}",
                    method,
                    path,
                    traceId,
                    sw.ElapsedMilliseconds);
                throw;
            }

            sw.Stop();

            Log.Information(
                "Finished request {Method} {Path} TraceId={TraceId} StatusCode={StatusCode} DurationMs={Duration}",
                method,
                path,
                traceId,
                (int)response.StatusCode,
                sw.ElapsedMilliseconds);

            return response;
        }
    }
}
