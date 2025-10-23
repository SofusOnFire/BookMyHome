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
	internal class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("User");
			builder.HasKey(user => user.Id);

			//Relations
			builder
				.HasMany(user => user.Bookings)
				.WithOne(booking => booking.User)
				.HasForeignKey(booking => booking.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasMany(user => user.Accomodations)
				.WithOne(accomodations => accomodations.User)
				.HasForeignKey(accomodations => accomodations.UserId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
