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
        public Booking CreateBooking(int accomodationId, DateOnly startTime, DateOnly endTime);
    }
}
