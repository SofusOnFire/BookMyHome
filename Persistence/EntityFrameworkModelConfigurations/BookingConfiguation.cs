using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Persistence.EntityFrameworkModelConfigurations
{
    internal class BookingConfiguation : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(booking => booking.Id);

            // Relations

            builder.HasOne(booking => booking.User)
                .WithMany(user => user.Bookings)
                .HasForeignKey(booking => booking.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(booking => booking.Accomodation)
                .WithMany(accomodation => accomodation.Bookings)
                .HasForeignKey(booking => booking.AccomodationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
