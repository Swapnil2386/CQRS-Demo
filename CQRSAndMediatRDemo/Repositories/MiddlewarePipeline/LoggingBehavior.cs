using MediatR;

namespace CQRSAndMediatRDemo.Repositories.MiddlewarePipeline
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Handling {RequestType}", typeof(TRequest).Name);
            var response = await next();
            _logger.LogInformation("Handled {RequestType}", typeof(TRequest).Name);
            return response;
        }
    }
}
