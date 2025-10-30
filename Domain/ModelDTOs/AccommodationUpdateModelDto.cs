using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class AccommodationUpdateModelDto
    {
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public string HouseRules { get; set; }
        public string Photo { get; set; }
        public bool Availability { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
