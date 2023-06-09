using Microsoft.AspNetCore.Builder;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Middleware.Telemetry
{
    public static class CorrelationMiddlewareExtension
    {
        public static IApplicationBuilder UseCorrelationMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CorrelationMiddleware>();
        }
    }
}
