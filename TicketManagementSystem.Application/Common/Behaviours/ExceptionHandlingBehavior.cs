using TicketManagementSystem.Application.Exceptions;
using MediatR;

namespace TicketManagementSystem.Application.Common.Behaviours
{
    public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (ValidationException ex)
            {
                // Log or process validation exceptions
                throw new ApplicationException($"Validation error: {string.Join(", ", ex.Errors)}");
            }
            catch (UnauthorizedAccessException)
            {
                throw new ApplicationException("Unauthorized access.");
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException($"Validation error: {string.Join(", ", ex.Message)}");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                throw new ApplicationException($"Validation error: {ex.Message}");
            }
        }
    }
}
