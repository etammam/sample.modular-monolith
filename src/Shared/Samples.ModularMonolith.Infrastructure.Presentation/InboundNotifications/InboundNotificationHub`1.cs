using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Samples.ModularMonolith.Services.Generic.CurrentUser;
using System;
using System.Threading.Tasks;

namespace Samples.ModularMonolith.Infrastructure.Presentation.InboundNotifications
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InboundNotificationHub<T> : Hub<T>
        where T : InboundNotification
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly InboundNotificationConnectorsMap _connectors;

        public InboundNotificationHub(ICurrentUserService currentUserService, InboundNotificationConnectorsMap connectors)
        {
            _currentUserService = currentUserService;
            _connectors = connectors;
        }

        /// <summary>
        /// connect and combine the connection id beside current logged in user.
        /// </summary>
        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var userId = _currentUserService.UserId();
            _connectors.AddConnection(connectionId, userId);
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var userId = _currentUserService.UserId();
            _connectors.RemoveConnection(connectionId, userId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
