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
    internal class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facility");
            builder.HasKey(facility => facility.Id);

            // Relations

            builder.HasMany(facility => facility.FacilityBridges)
                .WithOne(facilityBridges => facilityBridges.Facility)
                .HasForeignKey(facilityBridges => facilityBridges.FacilityId);
        }
    }
}
