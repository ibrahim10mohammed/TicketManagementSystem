using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Domain.Entities;

namespace TicketManagementSystem.Infrastructure.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<Microsoft.AspNetCore.Identity.IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicitly ignore DomainEvent
            modelBuilder.Entity<Ticket>(entity =>
       {
           entity.HasKey(e => e.Id);
           entity.Property(e => e.PhoneNumber).IsRequired();
           entity.OwnsOne(e => e.Address);
       });
        }
    }
}
