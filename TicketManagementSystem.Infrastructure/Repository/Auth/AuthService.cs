using Microsoft.AspNetCore.Identity;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Domain.Repository;
using TicketManagementSystem.Domain.ViewModels;
using TicketManagementSystem.Infrastructure.DataContext;

namespace TicketManagementSystem.Infrastructure.Repository.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtProvider _jwtProvider;
        private readonly ApplicationDbContext _dbContext;

        public AuthService(UserManager<IdentityUser> userManager, IJwtProvider jwtProvider, ApplicationDbContext context)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
            _dbContext = context;
        }
        public async Task<AuthenticationVm> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                throw new UnauthorizedAccessException("Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtProvider.GenerateToken(user, roles);

            var refreshToken = _jwtProvider.GenerateRefreshToken();
            var token = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
            _dbContext.RefreshTokens.Add(token);
            await _dbContext.SaveChangesAsync();

            return new AuthenticationVm
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<bool> RegisterAsync(string email, string password, string role)
        {
            var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded) return false;

            await _userManager.AddToRoleAsync(user, role);
            return true;
        }
    }
}
