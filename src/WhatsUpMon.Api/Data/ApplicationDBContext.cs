using Microsoft.EntityFrameworkCore;
using WhatsUpMon.Api.Models;

namespace WhatsUpMon.Api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        // DbSet properties to represent collections of each entity type
        public DbSet<Map> Maps { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType> DeviceTypes { get; set; }

        // Configures the schema needed for the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship between Map and Device
            modelBuilder.Entity<Map>()
                .HasMany(m => m.Devices) // Map has many Devices
                .WithMany(d => d.Maps) // Device has many Maps
                .UsingEntity(j => j.ToTable("MapDevice")); // This creates a join table named MapDevice

            // Configure the one-to-many relationship between DeviceType and Device
            modelBuilder.Entity<DeviceType>()
                .HasMany(dt => dt.Devices) // DeviceType has many Devices
                .WithOne(d => d.DeviceType) // Device has one DeviceType
                .HasForeignKey(d => d.DeviceTypeId); // Foreign key in Device pointing to DeviceType

            // Additional configurations can be added here, such as configuring
            // field lengths, indices, and other constraints as necessary.

            // Seed DeviceType data
            modelBuilder.Entity<DeviceType>().HasData(
                new DeviceType { DeviceTypeId = 1, Name = "Server" },
                new DeviceType { DeviceTypeId = 2, Name = "Switch" },
                new DeviceType { DeviceTypeId = 3, Name = "Router" }
            );
        }
    }
}
