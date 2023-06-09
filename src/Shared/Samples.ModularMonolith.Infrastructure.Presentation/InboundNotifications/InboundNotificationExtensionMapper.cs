using Microsoft.AspNetCore.Builder;

namespace Samples.ModularMonolith.Infrastructure.Presentation.InboundNotifications
{
    public static class InboundNotificationExtensionMapper
    {
        public static WebApplication MapNotificationHub<T>(this WebApplication app, string route)
            where T : InboundNotification
        {
            app.MapHub<InboundNotificationHub<T>>(route);
            return app;
        }
    }
}
