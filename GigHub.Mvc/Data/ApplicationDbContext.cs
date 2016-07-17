using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GigHub.Mvc.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GigHub.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Attendance>()
                .HasKey(a => new { a.GigId, a.AttendeeId });

            builder.Entity<Attendance>()
                .HasOne(a => a.Gig)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Following>()
                .HasKey(f => new { f.FollowerId, f.FolloweeId });

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithOne(f => f.Followee)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Followees)
                .WithOne(f => f.Follower)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        

    }
}
