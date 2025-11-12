using Microsoft.EntityFrameworkCore;
using GardenManager.Models;

namespace GardenManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
        options)
            : base(options)
        {
        } 
        public DbSet<User> Users { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<GardenPlot> GardenPlots { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<FertilizationPlan> FertilizationPlans { get; set; }
        public DbSet<PlantCompanion> PlantCompanions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure relationships
            modelBuilder.Entity<Garden>()
            .HasMany(g => g.Plots)
            .WithOne(p => p.Garden)
            .HasForeignKey(p => p.GardenId)
            .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Sensor>()
            .Property(s => s.Type)
            .HasConversion<string>();
        }
    }
}