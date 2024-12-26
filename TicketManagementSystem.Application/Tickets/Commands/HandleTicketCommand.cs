using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Application.Tickets.Commands
{
    public class HandleTicketCommand : IRequest<Boolean>
    {
        public Guid Id { get; set; }
    }
}
