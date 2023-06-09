using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.ModularMonolith.Infrastructure.Events.Integrations
{
    internal class IntegrationEventHookerInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _publisherService;

        public IntegrationEventHookerInterceptor(IPublisher publisherService)
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
                    if (!entity.IsAssignableTo(typeof(IHaveIntegrationEvents)))
                    {
                        continue;
                    }

                    List<IntegrationEventMessage> events = IntegrationEventInvoker.GetEvents(entity.Name);
                    foreach (IntegrationEventMessage item in events)
                    {
                        if (item.TriggeredIn > 0)
                        {
                            BackgroundJob.Schedule(() => Invoke(item.Event), TimeSpan.FromMinutes(item.TriggeredIn));
                            IntegrationEventInvoker.Remove(item);
                        }
                        else
                        {
                            BackgroundJob.Enqueue(() => Invoke(item.Event));
                            IntegrationEventInvoker.Remove(item);
                        }
                    }
                }
            }

            return saveChangesResult;
        }

        [Queue("integration-events")]
        public async Task Invoke(IIntegrationEvent @event)
        {
            await _publisherService.Publish(@event);
        }
    }
}
