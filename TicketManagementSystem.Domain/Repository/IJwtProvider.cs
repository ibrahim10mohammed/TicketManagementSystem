using Microsoft.AspNetCore.Identity;

namespace TicketManagementSystem.Domain.Repository
{
    public interface IJwtProvider
    {
        string GenerateToken(IdentityUser user, IList<string> roles);
        public string GenerateRefreshToken();
    }
}
