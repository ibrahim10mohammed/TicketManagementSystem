using TicketManagementSystem.Application.Common.Mappings;
using TicketManagementSystem.Domain.Entities;
using TicketManagementSystem.Domain.Enum;
using TicketManagementSystem.Domain.ValueObjects;

namespace TicketManagementSystem.Application.Tickets.ViewModels
{
    public class TicketVm: IMapFrom<Ticket>
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public TicketStatus Status { get; private set; }
        public string Color => GetColor();
        public string GetColor()
        {
            var timeElapsed = DateTime.UtcNow - CreatedAt;
            if (timeElapsed.TotalMinutes >= 60)
                return "Red";
            else if (timeElapsed.TotalMinutes >= 45)
                return "Blue";
            else if (timeElapsed.TotalMinutes >= 30)
                return "Green";
            else if (timeElapsed.TotalMinutes >= 15)
                return "Yellow";
            else
                return "Red";
        }
    }
}