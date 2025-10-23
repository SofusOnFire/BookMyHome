using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application
{
	public interface IBookingQueryRepository
	{
		public IEnumerable<Booking> GetAllBookingWithinTimespanGivenAccomodationId(DateOnly startTime, DateOnly endTime, int accomodationId);
	}
}
