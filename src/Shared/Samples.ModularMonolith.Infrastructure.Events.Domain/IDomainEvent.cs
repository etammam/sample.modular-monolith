using MediatR;

namespace Samples.ModularMonolith.Infrastructure.Events.Domain;

public interface IDomainEvent : INotification
{
    public string EntityName { get; set; }
}
