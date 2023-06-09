using MediatR;

namespace Samples.ModularMonolith.Infrastructure.Events.Integrations;

public interface IIntegrationEvent : INotification
{
    string NotifierEntityName { get; }
}