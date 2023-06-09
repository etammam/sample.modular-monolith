using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.ModularMonolith.Infrastructure.Events.Domain;

public static class DomainEventInvoker
{
    private static readonly List<DomainEventMessage> DomainEvents;

    static DomainEventInvoker()
    {
        DomainEvents = new List<DomainEventMessage>();
    }

    public static void Raise(IDomainEvent @event)
    {
        DomainEvents.Add(new DomainEventMessage(Guid.NewGuid(), @event.EntityName, @event));
    }

    public static void Raise(IDomainEvent @event, int triggeredIn)
    {
        DomainEvents.Add(new DomainEventMessage(Guid.NewGuid(), @event.EntityName, @event, triggeredIn));
    }

    public static void Remove(DomainEventMessage message)
    {
        DomainEvents.Remove(message);
    }

    public static void Clear()
    {
        DomainEvents.Clear();
    }

    public static List<DomainEventMessage> GetEvents()
    {
        return DomainEvents;
    }

    public static List<DomainEventMessage> GetEvents(string invokerName)
    {
        return DomainEvents.Where(@event => @event.InvokerName == invokerName).ToList();
    }
}