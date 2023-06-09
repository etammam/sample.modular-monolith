using Microsoft.AspNetCore.Builder;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Middleware.Exceptions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
