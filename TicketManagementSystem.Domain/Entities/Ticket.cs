using System.Drawing;
using System.Text.Json.Serialization;
using TicketManagementSystem.Domain.Enum;
using TicketManagementSystem.Domain.ValueObjects;

namespace TicketManagementSystem.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public TicketStatus Status { get; private set; }
        private Ticket() { }
        public Ticket(string phoneNumber, Address address)
        {
            CreatedAt = DateTime.UtcNow;
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Status = TicketStatus.New;
        }
        public void Handle()
        {
            if (Status == TicketStatus.Handled)
                throw new InvalidOperationException("Ticket is already handled.");
            Status = TicketStatus.Handled;
        }
        
    }
}
