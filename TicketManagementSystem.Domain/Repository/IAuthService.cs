using TicketManagementSystem.Domain.ViewModels;

namespace TicketManagementSystem.Domain.Repository
{
    public interface IAuthService
    {
        Task<AuthenticationVm> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(string email, string password, string role);
    }
}
