using Azure;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFrameworkModelConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class MSSQLServerDbContext : DbContext
    {
        public DbSet<Accommodation> Accomodations { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityBridge> FacilityBridges { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BookMyHome;Integrated Security=SSPI;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccommodationConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityBridgeConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
