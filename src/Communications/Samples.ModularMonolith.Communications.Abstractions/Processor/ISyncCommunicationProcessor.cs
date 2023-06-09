using MediatR;
using Samples.ModularMonolith.Communications.Abstractions.Answers;
using Samples.ModularMonolith.Communications.Abstractions.Questions;

namespace Samples.ModularMonolith.Communications.Abstractions.Processor;

public interface ISyncCommunicationProcessor<in TRemoteQuestion, TRemoteAnswer>
        : IRequestHandler<TRemoteQuestion, RemoteAnswerHost<TRemoteAnswer>>
        where TRemoteQuestion : IRemoteQuestion<TRemoteAnswer>, IRequest<RemoteAnswerHost<TRemoteAnswer>>
        where TRemoteAnswer : class
{
}
