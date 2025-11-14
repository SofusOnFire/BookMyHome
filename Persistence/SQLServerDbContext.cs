using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Persistence.EntityFrameworkModelConfigurations;

namespace Persistence
{
    public class SQLServerDbContext : DbContext
    {
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityBridge> FacilitiesBridge { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BookMyHome;Integrated Security=SSPI;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingConfiguation());
            modelBuilder.ApplyConfiguration(new UserConfiguation());
            modelBuilder.ApplyConfiguration(new AccomodationConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityBridgeConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityConfiguration());
        }

    }
}
