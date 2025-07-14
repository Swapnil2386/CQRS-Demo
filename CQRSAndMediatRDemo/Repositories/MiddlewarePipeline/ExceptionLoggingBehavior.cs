using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using MediatR;
using System.Text.Json;

namespace CQRSAndMediatRDemo.Repositories.MiddlewarePipeline
{
    public class ExceptionLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly LoggingDbContext _loggingDb;
        public ExceptionLoggingBehavior(LoggingDbContext loggingDb)
        {
            _loggingDb = loggingDb;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var exceptionLog = new ExceptionLog
                {
                    RequestType = typeof(TRequest).Name,
                    RequestData = JsonSerializer.Serialize(request),
                    ExceptionMessage = ex.Message,
                    StackTrace = ex.StackTrace,
                    Timestamp = DateTime.UtcNow
                };

                _loggingDb.ExceptionLogs.Add(exceptionLog);
                await _loggingDb.SaveChangesAsync(cancellationToken);

                throw; // rethrow after logging
            }
        }
    }
}
