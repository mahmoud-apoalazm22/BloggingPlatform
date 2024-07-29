using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BloggingPlatform.Application.Common.Behaviors;
public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Starting Request {@ReqestName} ,{@DateTimeUtc} ",
            typeof(TRequest).Name , DateTime.UtcNow);
 
        TResponse result = await next();

        if (result.IsError)
        {
            _logger.LogError(
                "Error in Request {@ReqestName} ,{@Error} ,{@DateTimeUtc} ",
                typeof(TRequest).Name, result.Errors, DateTime.UtcNow);
        }

        _logger.LogInformation(
        "Completed Request {@ReqestName} ,{@DateTimeUtc} ",
          typeof(TRequest).Name, DateTime.UtcNow);


        return result;
    }
}
