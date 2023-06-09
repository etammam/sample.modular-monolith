using System.Threading;
using System.Threading.Tasks;
using Samples.ModularMonolith.Communications.Abstractions.Questions;

namespace Samples.ModularMonolith.Communications.Abstractions.Callers.AsyncCaller
{
    public interface IAsyncCommunicationCaller
    {
        Task Tell<TRemoteQuestion>(TRemoteQuestion question, CancellationToken cancellationToken = default)
            where TRemoteQuestion : IRemoteQuestion;
    }
}
