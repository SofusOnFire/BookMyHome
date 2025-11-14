using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Facility
    {
        public int Id { get; init; }
        public string Description { get; set; }
        public List<FacilityBridge> FacilityBridges { get; }

        public Facility(string description)
        {
            Description = description;
        }
        private Facility()
        {

        }
    }
}
