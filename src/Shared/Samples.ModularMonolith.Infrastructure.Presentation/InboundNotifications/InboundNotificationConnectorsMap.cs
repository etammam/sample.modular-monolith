using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Samples.ModularMonolith.Infrastructure.Presentation.InboundNotifications
{
    public class InboundNotificationConnectorsMap
    {
        private readonly ConcurrentDictionary<Guid, List<string>> _connections;

        public InboundNotificationConnectorsMap()
        {
            _connections = new ConcurrentDictionary<Guid, List<string>>();
        }

        public void AddConnection(string connectionId, Guid userId)
        {
            var isUserHasConnection = _connections.TryGetValue(userId, out List<string> userConnections);
            if (isUserHasConnection)
            {
                _connections.AddOrUpdate(userId, (_) => AddValueFactory(connectionId, userConnections),
                (_, _) => UpdateValueFactory(connectionId, userConnections));
                return;
            }

            _connections.AddOrUpdate(userId, (_) => AddValueFactory(connectionId), UpdateValueFactory);
        }

        public void RemoveConnection(string connectionId, Guid userId)
        {
            var isUserHasConnection = _connections.TryGetValue(userId, out List<string> userConnections);
            if (isUserHasConnection)
            {
                _connections.Remove(userId, out userConnections);
            }
        }

        public string GetConnectionId(Guid userId)
        {
            _connections.TryGetValue(userId, out List<string> userConnections);
            return userConnections?.FirstOrDefault();
        }

        public List<string> GetConnectionIds(Guid userId)
        {
            _connections.TryGetValue(userId, out List<string> connections);
            return connections == null ? new List<string>() : connections.ToList();
        }

        public List<Guid> GetConnectedUsers()
        {
            return _connections.Keys.ToList();
        }

        private List<string> UpdateValueFactory(Guid arg1, List<string> arg2)
        {
            throw new NotImplementedException();
        }

        private List<string> AddValueFactory(string connectionId)
        {
            var userConnections = new List<string> { connectionId };
            return userConnections;
        }

        private List<string> UpdateValueFactory(string connectionId, List<string> userConnections)
        {
            if (userConnections.Contains(connectionId))
            {
                return userConnections;
            }

            userConnections.Add(connectionId);
            return userConnections;
        }

        private List<string> AddValueFactory(string connectionId, List<string> userConnections)
        {
            if (!userConnections.Contains(connectionId))
            {
                userConnections.Add(connectionId);
                return userConnections;
            }

            return userConnections;
        }
    }
}
