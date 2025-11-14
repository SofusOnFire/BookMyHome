using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;

namespace xUnitTests
{
	public class BookingEntityTest
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

		//1) BookingDate < Datetime.Now
		[Fact]
		public static void BookingCreation_ShouldPass_WhenGivenCorrectInformation()
		{
			// Arrange
			int id = 1;
			int accomodationId = 1;
			int userId = 1;
			DateOnly startTime = DateOnly.FromDateTime(DateTime.Now);
			DateOnly endTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
			string approvalStatus = "Pending";
			DateTime creationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

			// Act
			Booking booking = new Booking(id, userId, accomodationId, startTime, endTime, approvalStatus, creationDate);


			// Assert
			Assert.Equal(id, booking.Id);
			Assert.Equal(userId, booking.UserId);
			Assert.Equal(accomodationId, booking.AccomodationId);
			Assert.Equal(startTime, booking.StartTime);
			Assert.Equal(endTime, booking.EndTime);
			Assert.Equal(approvalStatus, booking.ApprovalStatus);
			Assert.Equal(creationDate, booking.CreationDate);
		}

		//1) BookingDate < Datetime.Now
		[Fact]
		public static void BookingCreation_ShouldThrowError_WhenGivenStartDateFromThePast()
		{
			// Arrange
			int id = 1;
			int accomodationId = 1;
			int userId = 1;
			DateOnly startTime = DateOnly.FromDateTime(DateTime.Now.AddDays(-2));
			DateOnly endTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
			string approvalStatus = "Pending";
			DateTime creationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

			// Act
			// Assert
			Assert.Throws<Exception>(
				() => new Booking(id, userId, accomodationId, startTime, endTime, approvalStatus, creationDate));
		}

		//4) EndDate > StartDate
		[Fact]
		public static void BookingCreation_ShouldThrowError_WhenGivenStartDateIsLaterThanEndDate()
		{
			// Arrange
			int id = 1;
			int accomodationId = 1;
			int userId = 1;
			DateOnly startTime = DateOnly.FromDateTime(DateTime.Now.AddDays(2));
			DateOnly endTime = DateOnly.FromDateTime(DateTime.Now);
			string approvalStatus = "Pending";
			DateTime creationDate = DateTime.Parse(DateTime.Now.ToShortTimeString());

			// Assert
			Assert.Throws<Exception>(
				() => new Booking(id, userId, accomodationId, startTime, endTime, approvalStatus, creationDate));
		}
	}
}
