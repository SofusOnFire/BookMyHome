using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Booking
{
    public class Booking
    {
        public int Id { get; init; }
        public DateOnly StartTime { get; set; }
        public DateOnly EndTime { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreationDate { get; set; }

        public Booking(int id, DateOnly startTime, DateOnly endTime, string approvalStatus, DateTime creationDate)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            ApprovalStatus = approvalStatus;
            CreationDate = creationDate;

            ValidateBookingInformation();
        }

        private void ValidateBookingInformation()
        {
            if (StartTime < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new Exception();
            }

            if (StartTime > EndTime)
            {
                throw new Exception();
            }
        }

    }
}
