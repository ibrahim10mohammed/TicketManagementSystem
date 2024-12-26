using MediatR;

namespace TicketManagementSystem.Application.Auth.Commands
{
    public class RegisterCommand :IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
