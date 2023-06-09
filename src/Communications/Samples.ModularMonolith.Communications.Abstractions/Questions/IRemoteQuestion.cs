using MediatR;
using Samples.ModularMonolith.Communications.Abstractions.Answers;

namespace Samples.ModularMonolith.Communications.Abstractions.Questions;

public interface IRemoteQuestion<TRemoteAnswer> : IRequest<RemoteAnswerHost<TRemoteAnswer>>
        where TRemoteAnswer : class
{
    public string ModuleName { get; }

    public string ActorName { get; }
}

public interface IRemoteQuestion : IRequest
{
    public string ModuleName { get; }

    public string ActorName { get; }
}
