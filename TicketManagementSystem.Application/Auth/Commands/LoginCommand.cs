using MediatR;
using TicketManagementSystem.Domain.ViewModels;

namespace TicketManagementSystem.Application.Auth.Commands
{
    public class LoginCommand : IRequest<AuthenticationVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
