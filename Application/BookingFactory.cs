using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.CustomExceptions;
using Domain.FactoryInterfaces;
using Domain.Models;

namespace Application

{
	public class BookingFactory : IBookingFactory
	{
		readonly IBookingQueryRepository _repository;

		public BookingFactory(IBookingQueryRepository repository)
		{
			_repository = repository;
		}

		public Booking CreateBooking(DateOnly startTime, DateOnly endTime, int accomodationId, int userId)
		{
			IEnumerable<Booking> potentielOverlappingBooking = _repository.GetAllBookingWithinTimespanGivenAccomodationId(startTime, endTime, accomodationId);

			if (potentielOverlappingBooking.Any(booking => booking.ApprovalStatus == "Approved"))
			{
				throw new OverlappingBookingException();
			}

			return new Booking(startTime, endTime, accomodationId, userId);
		}
	}
}
