using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using System.Text.Json;

namespace CQRSAndMediatRDemo.Repositories.MiddlewarePipeline
{
    public class DbLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : notnull
    {
        private readonly LoggingDbContext _logDbContext;

        public DbLoggingBehavior(LoggingDbContext loggingDbContext) {
        _logDbContext = loggingDbContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestLog = new RequestLog
            {
                RequestType = typeof(TRequest).Name,
                RequestData = JsonSerializer.Serialize(request),
                Timestamp = DateTime.UtcNow
            };
            _logDbContext.RequestLogs.Add(requestLog);
            await _logDbContext.SaveChangesAsync(cancellationToken);

            return await next();
        }
    }
}
