using System.Threading;
using System.Threading.Tasks;
using Samples.ModularMonolith.Communications.Abstractions.Answers;
using Samples.ModularMonolith.Communications.Abstractions.Questions;

namespace Samples.ModularMonolith.Communications.Abstractions.Callers.SyncCaller;

public interface ISyncCommunicationCaller
{
    Task<RemoteAnswerHost<TRemoteAnswer>> Ask<TRemoteQuestion, TRemoteAnswer>(TRemoteQuestion question, CancellationToken cancellationToken = default)
        where TRemoteQuestion : IRemoteQuestion<TRemoteAnswer>
        where TRemoteAnswer : class;
}
