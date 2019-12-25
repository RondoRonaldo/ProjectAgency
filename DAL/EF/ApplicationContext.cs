using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUserEntity, IdentityRole, string>
    {
        public DbSet<UserProfileEntity> UserProfiles { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<DistrictEntity> Districts { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CommentEntity>()
                .HasOne(p => p.Request)
                .WithMany(t => t.Comment)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RequestEntity>()
               .HasOne(p => p.UserProfile)
               .WithMany(t => t.Requests)
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
