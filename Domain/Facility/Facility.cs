using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Facility
{
    public class Facility
    {
        public int Id { get; init; }
        public string Description { get; set; }
        public Facility(string description)
        {
            Description = description;
        }
    }
}
