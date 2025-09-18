using Microsoft.EntityFrameworkCore;
using TravelData.Models;

namespace TravelData.Data
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) { }

        public DbSet<Traveler> Travelers { get; set; } = null!;
        public DbSet<TravelerProfile> TravelerProfiles { get; set; } = null!;
        public DbSet<AdventurePackage> AdventurePackages { get; set; } = null!;
        public DbSet<Guide> Guides { get; set; } = null!;
        public DbSet<TravelerAdventure> TravelerAdventures { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Traveler>()
                .HasOne(t => t.Profile)
                .WithOne(p => p.Traveler)
                .HasForeignKey<TravelerProfile>(p => p.TravelerId);

            modelBuilder.Entity<Guide>()
                .HasMany(g => g.AdventurePackages)
                .WithOne(p => p.Guide)
                .HasForeignKey(p => p.GuideId);

            modelBuilder.Entity<TravelerAdventure>()
                .HasKey(ta => new { ta.TravelerId, ta.AdventurePackageId });

            modelBuilder.Entity<Traveler>()
                .HasIndex(t => t.Email).IsUnique();

            modelBuilder.Entity<Traveler>()
                .HasIndex(t => t.PassportNumber).IsUnique();
        }
    }
}