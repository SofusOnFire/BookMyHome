using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.FactoryInterfaces
{
	public interface IBookingFactory
	{
		public Booking CreateBooking(DateOnly startTime, DateOnly endTime, int accomodationId, int userId);

		/*
		public int Id { get; init; }
        public DateOnly StartTime { get; set; }
        public DateOnly EndTime { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreationDate { get; set; }
		 */
	}
}
