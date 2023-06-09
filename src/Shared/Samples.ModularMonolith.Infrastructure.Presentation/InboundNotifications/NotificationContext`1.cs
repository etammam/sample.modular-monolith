using Microsoft.AspNetCore.SignalR;

namespace Samples.ModularMonolith.Infrastructure.Presentation.InboundNotifications
{
    public class NotificationContext<T> : INotificationContext<T>
        where T : InboundNotification
    {
        public NotificationContext(IHubContext<InboundNotificationHub<T>> hubContext, InboundNotificationConnectorsMap connectors)
        {
            HubContext = hubContext;
            Connectors = connectors;
        }

        public IHubContext<InboundNotificationHub<T>> HubContext { get; }

        public InboundNotificationConnectorsMap Connectors { get; }
    }
}
