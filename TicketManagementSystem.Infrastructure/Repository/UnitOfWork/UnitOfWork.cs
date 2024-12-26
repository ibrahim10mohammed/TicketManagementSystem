using TicketManagementSystem.Domain.Repository;
using TicketManagementSystem.Infrastructure.DataContext;
using TicketManagementSystem.Infrastructure.Repository.TicketRepo;

namespace TicketManagementSystem.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITicketRepository _ticketRepository;


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _ticketRepository =new TicketRepository(dbContext);
        }
        public ITicketRepository Tickets => _ticketRepository;

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
