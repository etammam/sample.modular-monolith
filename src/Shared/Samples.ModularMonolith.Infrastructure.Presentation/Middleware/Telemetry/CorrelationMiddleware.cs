using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Middleware.Telemetry
{
    public class CorrelationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (Activity.Current != null)
            {
                var traceId = Activity.Current.TraceId;
                context.Response.Headers.Add("x-correlation-id", new StringValues(traceId.ToString()));
            }

            await next(context);
        }
    }
}
