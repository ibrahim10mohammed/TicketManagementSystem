using MediatR;
using TicketManagementSystem.Domain.Repository;
using TicketManagementSystem.Domain.ViewModels;

namespace TicketManagementSystem.Application.Auth.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationVm>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<AuthenticationVm> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authResults =  await _authService.LoginAsync(request.Email, request.Password);
            return new AuthenticationVm
            {
                RefreshToken = authResults.RefreshToken,
                AccessToken = authResults.AccessToken,
            };
        }
    }
}
