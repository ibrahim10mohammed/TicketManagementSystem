using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketRepository Tickets { get; }
        Task<int> CommitAsync();
        void Rollback();
    }
}
