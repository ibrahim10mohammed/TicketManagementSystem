using Hangfire;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Application.Jobs;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Domain.Repository;
using TicketManagementSystem.Domain.ValueObjects;

namespace TicketManagementSystem.Application.Tickets.Commands
{
    public class HandleTicketHandler : IRequestHandler<HandleTicketCommand, bool>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HandleTicketHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
        {
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetByIdAsync(request.Id);
            ticket.Handle();
            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}
