using Domain.FactoryInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Moq;
using Common.CustomExceptions;

namespace xUnitTests
{
	public class BookingFactoryTest
	{
		//Domain laget for Booking - incl.relevante unit test til nedestående - implementeres.Der er følgende domæne regler:
		//Man kan ikke booke i fortiden.
		//Booking sker kun på dato - dvs.uden angivelse af tidspunkt, men blot start dato og slutdato
		//En booking er fra og med startdato til og med slutdato
		//Slutdato skal ligge efter startdato
		//Der må ikke være overlappende bookings. Dvs.
		//Ved opret og redigering af booking skal det tjekkes at der ikke opstår overlappende bookings.Sker det skal der kastes en Custom exception - "OverlapingBookingException"
		/*

		2) Datetime.Date != Datetime
		3) BookingDate == StartDate + EndDate
		4) EndDate > StartDate
		5) Ingen overlap -> "OverlapingBookingException"

		public int Id { get; init; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreationDate { get; set; }
		*/
		[Fact]
		public static void BookingCreation_ShouldPass_WhenGivenCorrectInformation()
		{
			// Arrange'
			int accomodationId = 1;
			DateOnly startTime = DateOnly.FromDateTime(DateTime.Now);
			DateOnly endTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
			string approvalStatus = "Pending";
			DateTime creationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
			Mock<IBookingQueryRepository> repository = new Mock<IBookingQueryRepository>();


			BookingFactory bookingFactory = new BookingFactory(repository.Object);

			// Act
			Booking booking = bookingFactory.CreateBooking(startTime, endTime, accomodationId);


			// Assert
			Assert.Equal(startTime, booking.StartTime);
			Assert.Equal(endTime, booking.EndTime);
			Assert.Equal(approvalStatus, booking.ApprovalStatus);
			Assert.Equal(creationDate, booking.CreationDate);
		}

		[Fact]
		public static void BookingCreation_ShouldGiveOverlapingBookingException_WhenGivenABookingDurationWhichIsOverlappingWithExistingBookings()
		{
			// Test Entity Arrange
			int accomodationId = 1;
			DateOnly startTime = DateOnly.FromDateTime(DateTime.Now);
			DateOnly endTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));

			// Moq Arrange
			int moqId = 1;
			int moqAccomodationId = 1;
			DateOnly moqStartTime = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
			DateOnly moqEndTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
			string moqApprovalStatus = "Approved";
			DateTime mogCreationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

			List<Booking> iBookingQueryReponseList = new List<Booking>();
			iBookingQueryReponseList.Add(new Booking(moqId, moqAccomodationId, moqStartTime, moqEndTime, moqApprovalStatus, mogCreationDate));

			Mock<IBookingQueryRepository> repository = new Mock<IBookingQueryRepository>();
			repository
				.Setup(repo => repo.GetAllBookingWithinTimespanGivenAccomodationId(startTime, endTime, accomodationId))
				.Returns(iBookingQueryReponseList);
				

			BookingFactory bookingFactory = new BookingFactory(repository.Object);

			// Act
			// Assert
			Assert.Throws<OverlappingBookingException>(
				() => bookingFactory.CreateBooking(startTime, endTime, accomodationId));
		}
	}
}
