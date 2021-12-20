using MediatR;

namespace WebApi.Handlers
{
    public abstract class TodoAppRequestHandler<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest
    {
        private readonly ILogger _logger;

        protected TodoAppRequestHandler(ILogger logger)
        {
            _logger = logger;
        }

        async Task<Unit> IRequestHandler<TRequest, Unit>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");

            try
            {
                await Handle(request, cancellationToken).ConfigureAwait(false);

                _logger.LogInformation($"Handled {typeof(TRequest).Name}");

                return Unit.Value;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Handled with error {typeof(TRequest).Name}");

                throw;
            }
        }
        
        protected abstract Task Handle(TRequest request, CancellationToken cancellationToken);
    }
    
    public abstract class TodoAppRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;

        protected TodoAppRequestHandler(ILogger logger)
        {
            _logger = logger;
        }

        async Task<TResponse> IRequestHandler<TRequest, TResponse>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");

            try
            {
                var result = await Handle(request, cancellationToken).ConfigureAwait(false);

                _logger.LogInformation($"Handled {typeof(TRequest).Name}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Handled with error {typeof(TRequest).Name}");

                throw;
            }
        }
        
        protected abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
