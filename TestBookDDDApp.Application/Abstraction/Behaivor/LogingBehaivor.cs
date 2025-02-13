using MediatR;

namespace TestBookDDDApp.Abstraction.Behaivor;

public sealed class LogingBehaivor<TRequest,TResponse>  : IPipelineBehavior<TRequest,TResponse>
{
    private readonly ILogger<LogingBehaivor<TRequest, TResponse>> _logger;
    public LogingBehaivor(ILogger<LogingBehaivor<TRequest,TResponse>> logger)
    {
        this._logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var methodName = request?.GetType().Name;
            _logger.LogInformation($"Start executing method {methodName}");
            var response = await next();
            _logger.LogInformation($"Executed method {methodName}");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Executed with error\n {ex.Message}");
            throw;
        }
    }
}