using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Accomodation
{
    public class Accomodation
    {
        public int Id { get; init; }
        public string Location { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public string HouseRules { get; set; }
        public string Photo { get; set; }
        public bool Availability { get; set; }

        public Accomodation(string location, string type, decimal price, string houseRules, string photo, bool availability)
        {
            Location = location;
            Type = type;
            Price = price;
            HouseRules = houseRules;
            Photo = photo;
            Availability = availability;
        }
    }
}
