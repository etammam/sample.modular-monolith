using System;

namespace Samples.ModularMonolith.Communications.Abstractions.Answers;

public class RemoteAnswerHost<TRemoteAnswer>
        where TRemoteAnswer : class
{
    public RemoteAnswerHost()
    {
    }

    public RemoteAnswerHost(TRemoteAnswer answer)
    {
        IsSuccess = true;
        Answer = answer;
    }

    public RemoteAnswerHost(Exception exception)
    {
        Exception = exception;
        IsSuccess = false;
    }

    public TRemoteAnswer Answer { get; set; }

    public bool IsSuccess { get; set; }

    public Exception Exception { get; set; }
}
