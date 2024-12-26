using MediatR;
using TicketManagementSystem.Application.Common.ViewModels;
using TicketManagementSystem.Application.Tickets.ViewModels;

namespace TicketManagementSystem.Application.Tickets.Queries
{
    public class GetTicketsQuery: IRequest<PaginatedResponse<TicketVm>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
