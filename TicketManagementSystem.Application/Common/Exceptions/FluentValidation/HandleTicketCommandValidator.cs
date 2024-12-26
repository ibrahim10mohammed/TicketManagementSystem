using FluentValidation;
using TicketManagementSystem.Application.Tickets.Commands;

namespace TicketManagementSystem.Application.Common.Exceptions.FluentValidation
{
    public class HandleTicketCommandValidator : AbstractValidator<HandleTicketCommand>
    {
        public HandleTicketCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("TicketId is required.").Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("TicketId must be a valid GUID."); ;
        }
    }
}
