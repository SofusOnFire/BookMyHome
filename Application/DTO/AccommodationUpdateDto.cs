using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AccommodationUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public string HouseRules { get; set; }
        public string Photo { get; set; }
        public bool Availability { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
