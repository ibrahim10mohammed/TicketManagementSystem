using MediatR;

namespace TicketManagementSystem.Application.Tickets.Commands
{
    public record CreateTicketCommand(string PhoneNumber, string Governorate, string City, string District) : IRequest<Guid>;
}
