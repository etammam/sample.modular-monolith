using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Communications.Abstractions.Callers.AsyncCaller;
using Samples.ModularMonolith.Communications.Abstractions.Callers.SyncCaller;

namespace Samples.ModularMonolith.Communications.Abstractions
{
    public static class DependencyInjection
    {
        public static void AddCommunications(this IServiceCollection services)
        {
            services.AddTransient<ISyncCommunicationCaller, SyncCommunicationCaller>();
            services.AddTransient<IAsyncCommunicationCaller, AsyncCommunicationCaller>();
        }
    }
}
