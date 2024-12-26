using Hangfire;
using MediatR;
using TicketManagementSystem.Application.Jobs;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Domain.Repository;
using TicketManagementSystem.Domain.ValueObjects;

namespace TicketManagementSystem.Application.Tickets.Commands
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
        {
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket(request.PhoneNumber,
                new Address(request.Governorate, request.City, request.District)
            );
            await _ticketRepository.CreateTicketAsync(ticket);

            await _unitOfWork.CommitAsync();
            // Schedule the job to mark the ticket as handled after 60 minutes
            BackgroundJob.Schedule<TicketJob>(job => job.MarkTicketAsHandled(ticket.Id), TimeSpan.FromMinutes(60));
            return ticket.Id;
        }
    }
}
