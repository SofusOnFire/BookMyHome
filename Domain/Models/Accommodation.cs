using Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Accommodation
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

        // EF mapping
        public User User { get; }
        public List<Booking> Bookings { get; }
        public List<FacilityBridge> FacilityBridges { get; }

        public void UpdateAccommodationModel(AccommodationUpdateModelDto accommodationUpdateModelDto)
        {
            UserId = accommodationUpdateModelDto.UserId;
            Price = accommodationUpdateModelDto.Price;
            HouseRules = accommodationUpdateModelDto.HouseRules;
            Photo = accommodationUpdateModelDto.Photo;
            Availability = accommodationUpdateModelDto.Availability;
            RowVersion = accommodationUpdateModelDto.RowVersion;
        }
    }
}
