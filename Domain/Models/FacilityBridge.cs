using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FacilityBridge
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int AccommodationId { get; set; }

        // EF mapping
        public Facility Facility { get; }
        public Accommodation Accommodation { get; }
    }
}
