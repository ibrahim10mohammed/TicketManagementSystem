using AutoMapper;
using MediatR;
using TicketManagementSystem.Application.Common.ViewModels;
using TicketManagementSystem.Application.Tickets.ViewModels;
using TicketManagementSystem.Domain.Repository;

namespace TicketManagementSystem.Application.Tickets.Queries
{
    public class GetTicketsQueryHandler: IRequestHandler<GetTicketsQuery, PaginatedResponse<TicketVm>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public GetTicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<TicketVm>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            var totalCount = _ticketRepository.GetTotalCountAsync();

            var tickets = _ticketRepository.GetAllTicketsAsync(request.PageNumber, request.PageSize);

            var booksList = _mapper.Map<List<TicketVm>>(tickets);
            return new PaginatedResponse<TicketVm>
            {
                Items = booksList,
                TotalCount = totalCount
            };
        }
    }
}
