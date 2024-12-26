using FluentValidation;
using TicketManagementSystem.Application.Auth.Commands;

namespace TicketManagementSystem.Application.Common.Exceptions.FluentValidation
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email is required.")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email must be a valid email address.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(x => x.Role).NotEmpty().WithMessage("Role is required.").Matches(@"^(Admin|User)$").WithMessage("Role must be either 'Admin' or 'User'."); ;
        }
    }
}
