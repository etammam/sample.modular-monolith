using System;

namespace Samples.ModularMonolith.Infrastructure.Events.Domain;

public record DomainEventMessage(
    Guid Id,
    string InvokerName,
    IDomainEvent Event,
    int TriggeredIn = 0
);