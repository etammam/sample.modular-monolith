using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Communications.Abstractions.Configurations;
using Samples.ModularMonolith.Communications.Abstractions.Questions;

namespace Samples.ModularMonolith.Communications.Abstractions.Callers.AsyncCaller
{
    public class AsyncCommunicationCaller : IAsyncCommunicationCaller
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ActorConfigurations _actorConfigurations;

        public AsyncCommunicationCaller(IServiceProvider serviceProvider, ActorConfigurations actorConfigurations)
        {
            _serviceProvider = serviceProvider;
            _actorConfigurations = actorConfigurations;
        }

        public Task Tell<TRemoteQuestion>(TRemoteQuestion question, CancellationToken cancellationToken = default)
            where TRemoteQuestion : IRemoteQuestion
        {
            var questionModuleName = question.ModuleName;
            var actorConfiguration = _actorConfigurations.Modules.SingleOrDefault(module => module.Name == questionModuleName);
            if (actorConfiguration == null)
                throw new ArgumentException(message: "actor system not configured");

            var actorContext = _serviceProvider.GetRequiredService<ActorSystem>();
            var actorSelector = actorContext.ActorSelection($"akka.tcp://{question.ModuleName}@{actorConfiguration.Host}:{actorConfiguration.Port}/user/{question.ActorName}");
            actorSelector.Tell(message: question);

            return Task.CompletedTask;
        }
    }
}
