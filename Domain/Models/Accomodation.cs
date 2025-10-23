using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Accomodation
    {
        public int Id { get; init; }
        public int UserId { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string HouseRules { get; set; }
        public string Photo { get; set; }
        public bool Availability { get; set; }

        public List<FacilityBridge> FacilityBridges { get; }
        public User User { get; }
        public List<Booking> Bookings { get; }

    }
}
