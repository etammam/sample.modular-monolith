using System;

namespace Samples.ModularMonolith.Infrastructure.Events.Integrations;

public record IntegrationEventMessage(Guid Id, string InvokerName, IIntegrationEvent Event, int TriggeredIn = 0);

