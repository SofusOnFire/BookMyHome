using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; init; }
        public string Email { get; set; }
        public string Language { get; set; }

        // EF mapping
        public List<Accommodation> Accommodations { get; }
        public List<Booking> Bookings { get; }
    }
}
