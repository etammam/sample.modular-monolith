using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.ModularMonolith.Infrastructure.Events.Integrations
{
    public static class IntegrationEventInvoker
    {
        private static readonly List<IntegrationEventMessage> DomainEvents;

        static IntegrationEventInvoker()
        {
            DomainEvents = new List<IntegrationEventMessage>();
        }

        public static void Raise(IIntegrationEvent @event)
        {
            DomainEvents.Add(new IntegrationEventMessage(Guid.NewGuid(), @event.NotifierEntityName, @event));
        }

        public static void Raise(IIntegrationEvent @event, int triggeredIn)
        {
            DomainEvents.Add(new IntegrationEventMessage(Guid.NewGuid(), @event.NotifierEntityName, @event, triggeredIn));
        }

        public static void Remove(IntegrationEventMessage message)
        {
            DomainEvents.Remove(message);
        }

        public static void Clear()
        {
            DomainEvents.Clear();
        }

        public static List<IntegrationEventMessage> GetEvents()
        {
            return DomainEvents;
        }

        public static List<IntegrationEventMessage> GetEvents(string invokerName)
        {
            return DomainEvents.Where(@event => @event.InvokerName == invokerName).ToList();
        }
    }
}
