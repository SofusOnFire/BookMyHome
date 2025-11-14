using Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public List<FacilityBridge> FacilityBridges { get; }
        public User User { get; }
        public List<Booking> Bookings { get; }
        public void UpdateAccomodation(AccomodationUpdateModelDTO accomodationUpdateModelDTO)
        {
            UserId = accomodationUpdateModelDTO.UserId;
            Price = accomodationUpdateModelDTO.Price;
            HouseRules = accomodationUpdateModelDTO.HouseRules;
            Photo = accomodationUpdateModelDTO.Photo;
            Availability = accomodationUpdateModelDTO.Availability;
            RowVersion = accomodationUpdateModelDTO.RowVersion;
        }
    }
}
