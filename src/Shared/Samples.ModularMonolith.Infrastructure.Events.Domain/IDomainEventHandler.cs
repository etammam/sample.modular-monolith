using System;
using MediatR;

namespace Samples.ModularMonolith.Infrastructure.Events.Domain;

public interface IDomainEventHandler<in T> : INotificationHandler<T>
    where T : IDomainEvent
{
}
