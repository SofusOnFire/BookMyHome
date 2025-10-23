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
        public int AccomodationId { get; set; }
		public DateOnly StartTime { get; set; }
        public DateOnly EndTime { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreationDate { get; set; }
        public Accomodation accomodation { get; }

        public Booking(int id, int accomodationId, DateOnly startTime, DateOnly endTime, string approvalStatus, DateTime creationDate)
        {
            Id = id;
            AccomodationId = accomodationId;
            StartTime = startTime;
            EndTime = endTime;
            ApprovalStatus = approvalStatus;
            CreationDate = DateTime.Parse(creationDate.ToShortTimeString());

            ValidateBookingInformation();
        }

		public Booking(DateOnly startTime, DateOnly endTime, int accomodationId)
		{
			AccomodationId = accomodationId;
			StartTime = startTime;
			EndTime = endTime;
            ApprovalStatus = "Pending";
			CreationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

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
