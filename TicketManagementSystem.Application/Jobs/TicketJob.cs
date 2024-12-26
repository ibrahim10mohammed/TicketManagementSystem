using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementSystem.Domain.Enum;
using TicketManagementSystem.Domain.Repository;

namespace TicketManagementSystem.Application.Jobs
{
    public class TicketJob
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketJob(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task MarkTicketAsHandled(Guid ticketId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket != null)
            {
                ticket.Handle();
                await _ticketRepository.UpdateAsync(ticket);
            }
        }
    }
}
