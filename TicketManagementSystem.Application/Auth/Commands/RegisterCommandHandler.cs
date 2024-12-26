using MediatR;
using TicketManagementSystem.Domain.Repository;

namespace TicketManagementSystem.Application.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterAsync(request.Email, request.Password, request.Role);
        }
    }
}
