using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityFrameworkModelConfigurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(booking => booking.Id);

            // Relations

            builder.HasOne(booking => booking.Accommodation)
                .WithMany(accommodation => accommodation.Bookings)
                .HasForeignKey(booking => booking.AccommodationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(booking => booking.User)
                .WithMany(user => user.Bookings)
                .HasForeignKey(booking => booking.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
