using FluentValidation;
using TicketManagementSystem.Application.Tickets.Commands;

namespace TicketManagementSystem.Application.Common.Exceptions.FluentValidation
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^01[01259]\d{8}$").WithMessage("Phone number must be a valid Egyptian number (e.g., 01144713724).");

            RuleFor(x => x.Governorate)
                .NotEmpty().WithMessage("Governorate is required.");    

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("District is required.");
        }
    }
}
