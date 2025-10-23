using Common;
using Domain.FactoryInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BookingFactory : IBookingFactory
    {
        readonly IBookingQueryRepository _repository;

        public BookingFactory(IBookingQueryRepository repository)
        {
            _repository = repository;
        }

        public Booking CreateBooking(int accomodationId, DateOnly startTime, DateOnly endTime)
        {
            IEnumerable<Booking> bookingsInDatabase = _repository.GetAllBookingsWithinTimespanByAccomodationId(accomodationId, startTime, endTime);

            if (bookingsInDatabase.Any(booking => booking.ApprovalStatus == "Approved"))
            {
                throw new OverlappingBookingException("Allerede booket på givent tidspunkt. Prøv igen.");
            }

            return new Booking(accomodationId, startTime, endTime);
        }
    }
}
