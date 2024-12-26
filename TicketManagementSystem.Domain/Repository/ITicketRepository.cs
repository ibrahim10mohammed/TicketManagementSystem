using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Domain.Repository
{
    public interface ITicketRepository
    {
        Task<Ticket> GetByIdAsync(Guid id);
        Task UpdateAsync(Ticket ticket);
        Task<Ticket> CreateTicketAsync(Ticket book);
        Task<List<Ticket>> UpdateTicketsColorsAsync();
        List<Ticket> GetAllTicketsAsync(int pageNumber, int pageSize);
        int GetTotalCountAsync();
    }
}
