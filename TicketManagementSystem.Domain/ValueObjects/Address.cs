using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Domain.ValueObjects
{
    public class Address
    {
        public string Governorate { get; private set; }
        public string City { get; private set; }
        public string District { get; private set; }

        public Address(string governorate, string city, string district)
        {
            Governorate = governorate ?? throw new ArgumentNullException(nameof(governorate));
            City = city ?? throw new ArgumentNullException(nameof(city));
            District = district ?? throw new ArgumentNullException(nameof(district));
        }

        // Required for EF Core
        private Address() { }
    }
}
