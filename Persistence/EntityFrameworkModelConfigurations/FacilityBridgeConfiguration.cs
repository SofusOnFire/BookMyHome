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
    internal class FacilityBridgeConfiguration : IEntityTypeConfiguration<FacilityBridge>
    {
        public void Configure(EntityTypeBuilder<FacilityBridge> builder)
        {
            builder.ToTable("FacilityBridge");
            builder.HasKey(facilityBridge => facilityBridge.Id);

            // Relations

            builder.HasOne(facilityBridge => facilityBridge.Accommodation)
                .WithMany(accommodation => accommodation.FacilityBridges)
                .HasForeignKey(facilityBridge => facilityBridge.AccommodationId);

            builder.HasOne(facilityBridge => facilityBridge.Facility)
                .WithMany(facility => facility.FacilityBridges)
                .HasForeignKey(facilityBridge => facilityBridge.FacilityId);
        }
    }
}
