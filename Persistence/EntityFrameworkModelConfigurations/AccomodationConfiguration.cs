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
    internal class AccomodationConfiguration : IEntityTypeConfiguration<Accomodation>
    {
        public void Configure(EntityTypeBuilder<Accomodation> builder)
        {
            builder.ToTable("Accomodation");
            builder.HasKey(accomodation => accomodation.Id);

            // Relations

            builder.HasOne(accomodation => accomodation.User)
                .WithMany(user => user.Accomodations)
                .HasForeignKey(accomodation => accomodation.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(accomodation => accomodation.Bookings)
                .WithOne(booking => booking.Accomodation)
                .HasForeignKey(booking => booking.AccomodationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(accomodation => accomodation.FacilityBridges)
                .WithOne(facilityBridge => facilityBridge.Accomodation)
                .HasForeignKey(facilityBridge => facilityBridge.AccommodationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
