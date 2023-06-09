using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Communications.Abstractions.Answers;
using Samples.ModularMonolith.Communications.Abstractions.Configurations;
using Samples.ModularMonolith.Communications.Abstractions.Questions;

namespace Samples.ModularMonolith.Communications.Abstractions.Callers.SyncCaller;

public class SyncCommunicationCaller : ISyncCommunicationCaller
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ActorConfigurations _actorConfigurations;

    public SyncCommunicationCaller(IServiceProvider serviceProvider, ActorConfigurations actorConfigurations)
    {
        _serviceProvider = serviceProvider;
        _actorConfigurations = actorConfigurations;
    }

    public async Task<RemoteAnswerHost<TRemoteAnswer>> Ask<TRemoteQuestion, TRemoteAnswer>(TRemoteQuestion question, CancellationToken cancellationToken = default)
        where TRemoteQuestion : IRemoteQuestion<TRemoteAnswer>
        where TRemoteAnswer : class
    {
        try
        {
            var questionModuleName = question.ModuleName;
            var actorConfiguration = _actorConfigurations.Modules.SingleOrDefault(module => module.Name == questionModuleName);
            if (actorConfiguration == null)
                throw new ArgumentException(message: "actor system not configured");

            var actorContext = _serviceProvider.GetRequiredService<ActorSystem>();
            var actorSelector = actorContext.ActorSelection($"akka.tcp://{question.ModuleName}@{actorConfiguration.Host}:{actorConfiguration.Port}/user/{question.ActorName}");
            var response = await actorSelector.Ask<TRemoteAnswer>(message: question, cancellationToken: cancellationToken);
            return new RemoteAnswerHost<TRemoteAnswer>(response);
        }
        catch (Exception e)
        {
            return new RemoteAnswerHost<TRemoteAnswer>(e);
        }
    }
}
