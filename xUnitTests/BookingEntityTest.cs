using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace xUnitTests
{
    public class BookingEntityTest
    {
        /*
        1) BookingDate < DateTime.Now
        2) DateTime.Date != DateTime
        3) BookingDate == StarteDate + EndDate
        4) EndDate > StartDate
        5) Ingen overlap -> "OverlappingBookingException"
            Man kan ikke booke i fortiden. */

        [Fact]
        public void BookingCreation_ShouldPass_WhenGivenCorrectInformation()
        {
            // Arrange
            int accomodationId = 1;
            DateOnly startTime = DateOnly.FromDateTime(DateTime.Now);
            DateOnly endTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
            string approvalStatus = "Pending";
            DateTime creationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

            // Act
            Booking booking = new Booking(accomodationId, startTime, endTime, approvalStatus, creationDate);

            // Assert
            Assert.Equal(startTime, booking.StartTime);
            Assert.Equal(endTime, booking.EndTime);
            Assert.Equal(approvalStatus, booking.ApprovalStatus);
            Assert.Equal(creationDate, booking.CreationDate);
        }

        [Fact]
        public void BookingDateInPast_ShouldThrowError()
        {
            // Arrange
            int accomodationId = 1;
            DateOnly startTime = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
            DateOnly endTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
            string approvalStatus = "Pending";
            DateTime creationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

            // Act & Assert
            Assert.Throws<Exception>(
                () => new Booking(accomodationId, startTime, endTime, approvalStatus, creationDate));
        }
    }
}
