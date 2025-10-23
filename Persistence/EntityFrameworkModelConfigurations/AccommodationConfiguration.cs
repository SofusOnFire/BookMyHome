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
    internal class AccommodationConfiguration : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.ToTable("Accommodation");
            builder.HasKey(accommodation => accommodation.Id);

            // Relations

            builder.HasOne(accommodation => accommodation.User)
                .WithMany(user => user.Accommodations)
                .HasForeignKey(accommodation => accommodation.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(accommodation => accommodation.Bookings)
                .WithOne(booking => booking.Accommodation)
                .HasForeignKey(booking => booking.AccommodationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(accommodation => accommodation.FacilityBridges)
                .WithOne(facilityBridge => facilityBridge.Accommodation)
                .HasForeignKey(facilityBridge => facilityBridge.AccommodationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
