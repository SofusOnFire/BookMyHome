using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Booking
    {
        public int Id { get; init; }
        public int AccommodationId { get; set; }
        public int UserId { get; set; }
        public DateOnly StartTime { get; set; }
        public DateOnly EndTime { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreationDate { get; set; }

        // EF mapping
        public Accommodation Accommodation { get; }
        public User User { get; }

        public Booking(int accommodationId, DateOnly startTime, DateOnly endTime, string approvalStatus, DateTime creationDate)
        {
            AccommodationId = accommodationId;
            StartTime = startTime;
            EndTime = endTime;
            ApprovalStatus = approvalStatus;
            CreationDate = DateTime.Parse(creationDate.ToShortTimeString());

            ValidateBookingInformation();
        }

        public Booking(int accommodationId, DateOnly startTime, DateOnly endTime)
        {
            AccommodationId = accommodationId;
            StartTime = startTime;
            EndTime = endTime;
            ApprovalStatus = "Pending";
            CreationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

            ValidateBookingInformation();
        }

        private void ValidateBookingInformation()
        {
            // Start time is in the past
            if (StartTime < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new Exception();
            }

            // End time comes before start time
            if (StartTime > EndTime)
            {
                throw new Exception();
            }
        }
    }
}
