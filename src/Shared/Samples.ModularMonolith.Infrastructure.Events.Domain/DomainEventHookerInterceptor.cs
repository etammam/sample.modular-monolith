using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.ModularMonolith.Infrastructure.Events.Domain
{
    public class DomainEventHookerInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _publisherService;

        public DomainEventHookerInterceptor(IPublisher publisherService)
        {
            _publisherService = publisherService;
        }

        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
            CancellationToken cancellationToken = default)
        {
            IEnumerable<Type> entities = eventData.Context?.ChangeTracker.Entries().Select(c => c.Metadata.ClrType);
            if (entities == null)
            {
                return await base.SavedChangesAsync(eventData, result, cancellationToken);
            }

            int saveChangesResult = await base.SavedChangesAsync(eventData, result, cancellationToken);
            if (saveChangesResult > 0)
            {
                foreach (Type entity in entities)
                {
                    if (!entity.IsAssignableTo(typeof(IHaveDomainEvent)))
                    {
                        continue;
                    }

                    List<DomainEventMessage> events = DomainEventInvoker.GetEvents(entity.Name);
                    foreach (DomainEventMessage item in events)
                    {
                        if (item.TriggeredIn > 0)
                        {
                            BackgroundJob.Schedule(() => Invoke(item.Event), TimeSpan.FromMinutes(item.TriggeredIn));
                            DomainEventInvoker.Remove(item);
                        }
                        else
                        {
                            BackgroundJob.Enqueue(() => Invoke(item.Event));
                            DomainEventInvoker.Remove(item);
                        }
                    }
                }
            }

            return saveChangesResult;
        }

        [Queue("domain-events")]
        public async Task Invoke(IDomainEvent @event)
        {
            await _publisherService.Publish(@event);
        }
    }
}
