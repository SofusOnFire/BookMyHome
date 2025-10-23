using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkModelConfigurations
{
	internal class FacilityConfiguration : IEntityTypeConfiguration<Facility>
	{
		public void Configure(EntityTypeBuilder<Facility> builder)
		{
			builder.ToTable("Facility");
			builder.HasKey(facility => facility.Id);

			//Relations
			builder
				.HasMany(facility => facility.FacilityBridges)
				.WithOne(facilityBridge => facilityBridge.Facility)
				.HasForeignKey(facilityBridge => facilityBridge.FacilityId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
