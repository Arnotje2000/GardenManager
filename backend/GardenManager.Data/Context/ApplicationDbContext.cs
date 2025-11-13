using Microsoft.EntityFrameworkCore;
using GardenManager.Core.Models;

namespace GardenManager.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        } 
        
        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<GardenPlot> GardenPlots { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<FertilizationPlan> FertilizationPlans { get; set; }
        public DbSet<PlantCompanion> PlantCompanions { get; set; }
        public DbSet<SensorAlert> SensorAlerts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // User Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256);
                entity.Property(e => e.PasswordHash)
                .IsRequired();
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(256);
                entity.HasIndex(e => e.Email)
                .IsUnique();
                entity.HasMany(e => e.Gardens)
                .WithOne(g => g.User)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            // Garden Configuration
            modelBuilder.Entity<Garden>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(256);
                entity.HasIndex(e => e.UserId);
                entity.HasMany(e => e.Plots)
                .WithOne(p => p.Garden)
                .HasForeignKey(p => p.GardenId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Sensors)
                .WithOne(s => s.Garden)
                .HasForeignKey(s => s.GardenId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            // GardenPlot Configuration
            modelBuilder.Entity<GardenPlot>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.GardenId);
                entity.HasIndex(e => e.PlantId);
                entity.HasOne(e => e.Plant)
                .WithMany(p => p.GardenPlots)
                .HasForeignKey(e => e.PlantId)
                .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(e => e.Sensors)
                .WithOne(s => s.GardenPlot)
                .HasForeignKey(s => s.GardenPlotId)
                .OnDelete(DeleteBehavior.SetNull);
                entity.HasMany(e => e.FertilizationPlans)
                .WithOne(f => f.GardenPlot)
                .HasForeignKey(f => f.GardenPlotId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            // Plant Configuration
            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(256);
                entity.HasMany(e => e.CompanionPlantsA)
                .WithOne(pc => pc.PlantA)
                .HasForeignKey(pc => pc.PlantAId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.CompanionPlantsB)
                .WithOne(pc => pc.PlantB)
                .HasForeignKey(pc => pc.PlantBId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            // Sensor Configuration
            modelBuilder.Entity<Sensor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);
                entity.Property(e => e.ExternalId)
                .IsRequired()
                .HasMaxLength(256);
                entity.HasIndex(e => e.GardenId);
                entity.HasIndex(e => new { e.GardenId, e.Type });
                entity.HasMany(e => e.Readings)
                .WithOne(r => r.Sensor)
                .HasForeignKey(r => r.SensorId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(e => e.Alerts)
                .WithOne(a => a.Sensor)
                .HasForeignKey(a => a.SensorId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            // SensorReading Configuration
            modelBuilder.Entity<SensorReading>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.SensorId, e.Timestamp })
                .IsUnique(false);
                entity.Property(e => e.Value)
                .HasPrecision(10, 2);
            });
            // SensorAlert Configuration
            modelBuilder.Entity<SensorAlert>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.SensorId);
                entity.HasIndex(e => e.CreatedAt);
            });
            // FertilizationPlan Configuration
            modelBuilder.Entity<FertilizationPlan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.GardenPlotId);
                entity.HasIndex(e => e.PlantId);
                entity.HasOne(e => e.Plant)
                .WithMany(p => p.FertilizationPlans)
                .HasForeignKey(e => e.PlantId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            // PlantCompanion Configuration
            modelBuilder.Entity<PlantCompanion>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => new { e.PlantAId, e.PlantBId })
                .IsUnique();
            });
        }
    }
}
