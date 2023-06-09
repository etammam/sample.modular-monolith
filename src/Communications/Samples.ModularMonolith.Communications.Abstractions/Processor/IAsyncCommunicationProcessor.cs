using MediatR;
using Samples.ModularMonolith.Communications.Abstractions.Questions;

namespace Samples.ModularMonolith.Communications.Abstractions.Processor
{
    public interface IAsyncCommunicationProcessor<in TRemoteQuestion>
        : IRequestHandler<TRemoteQuestion>
        where TRemoteQuestion : IRemoteQuestion, IRequest
    {
    }
}
