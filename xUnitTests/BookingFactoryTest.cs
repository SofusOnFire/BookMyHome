using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Common;
using Domain.Models;
using Moq;

namespace xUnitTests
{
    public class BookingFactoryTest
    {
        [Fact]
        public void BookingCreation_ShouldPass_WhenGivenCorrectInformation()
        {
            // Arrange
            int accomodationId = 1;
            DateOnly startTime = DateOnly.FromDateTime(DateTime.Now);
            DateOnly endTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
            string approvalStatus = "Pending";
            DateTime creationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            Mock<IBookingQueryRepository> repository = new Mock<IBookingQueryRepository>();

            BookingFactory bookingFactory = new BookingFactory(repository.Object);

            // Act
            Booking booking = bookingFactory.CreateBooking(accomodationId, startTime, endTime);

            // Assert
            Assert.Equal(startTime, booking.StartTime);
            Assert.Equal(endTime, booking.EndTime);
            Assert.Equal(approvalStatus, booking.ApprovalStatus);
            Assert.Equal(creationDate, booking.CreationDate);
        }

        [Fact]
        public void BookingCreation_ShouldThrowAnOverlappingException_WhenGivenABookingDurationWhichIsOverlappingWithExistingBookings()
        {
            // Arrange
                // Mocked booking
            int moqAccomodationId = 1;
            DateOnly moqStartTime = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
            DateOnly moqEndTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
            string moqApprovalStatus = "Approved";
            DateTime moqCreationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

                // Test booking
            int accomodationId = 1;
            DateOnly startTime = DateOnly.FromDateTime(DateTime.Now);
            DateOnly endTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));

            List<Booking> iBookingQueryResponseList = new List<Booking>() 
            { 
                new Booking(moqAccomodationId, moqStartTime, moqEndTime, moqApprovalStatus, moqCreationDate) 
            };

            Mock<IBookingQueryRepository> repository = new Mock<IBookingQueryRepository>();
            repository
                .Setup(repo => repo.GetAllBookingsWithinTimespanByAccomodationId(accomodationId, startTime, endTime))
                .Returns(iBookingQueryResponseList);

            BookingFactory bookingFactory = new BookingFactory(repository.Object);

            // Act & Assert
            Assert.Throws<OverlappingBookingException>(
                () => bookingFactory.CreateBooking(accomodationId, startTime, endTime));
        }
    }
}
