using Microsoft.AspNetCore.SignalR;

namespace Samples.ModularMonolith.Infrastructure.Presentation.InboundNotifications
{
    public interface INotificationContext<T>
        where T : InboundNotification
    {
        public IHubContext<InboundNotificationHub<T>> HubContext { get; }

        public InboundNotificationConnectorsMap Connectors { get; }
    }
}
