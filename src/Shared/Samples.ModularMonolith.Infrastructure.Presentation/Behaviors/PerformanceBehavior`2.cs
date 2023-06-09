using MediatR;
using Microsoft.Extensions.Logging;
using Samples.ModularMonolith.Services.Generic.CurrentUser;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.ModularMonolith.Infrastructure.Presentation.Behaviors;

public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUser;
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehavior(
        Stopwatch timer,
        ILogger<PerformanceBehavior<TRequest, TResponse>> logger,
        ICurrentUserService currentUser)
    {
        _timer = timer;
        _logger = logger;
        _currentUser = currentUser;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _timer.Start();
        var response = await next();
        _timer.Stop();
        var elapsedMilliseconds = _timer.ElapsedMilliseconds;
        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUser.UserId(Guid.Empty);
            var userName = _currentUser.UserName(string.Empty);

            _logger.LogWarning(
                "Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, request);
        }

        return response;
    }
}