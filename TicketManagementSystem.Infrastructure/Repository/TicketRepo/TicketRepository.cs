using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Domain.Repository;
using TicketManagementSystem.Infrastructure.DataContext;

namespace TicketManagementSystem.Infrastructure.Repository.TicketRepo
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TicketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Domain.Entities.Ticket> CreateTicketAsync(Domain.Entities.Ticket ticket)
        {
            await _dbContext.Tickets.AddAsync(ticket);
            return ticket;
        }

        public List<Ticket> GetAllTicketsAsync(int pageNumber, int pageSize)
        {
            return _dbContext.Tickets.ToList();
        }

        public async Task<Ticket> GetByIdAsync(Guid id)
        {
            return await _dbContext.Tickets.FindAsync(id);
        }

        public int GetTotalCountAsync()
        {
            return _dbContext.Tickets.Count();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Ticket>> UpdateTicketsColorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
