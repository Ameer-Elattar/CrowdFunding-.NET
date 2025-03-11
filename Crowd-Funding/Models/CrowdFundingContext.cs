using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crowd_Funding.Models
{
    public class CrowdFundingContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReport> CommentReports { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProjectPics> ProjectPics { get; set; }



        public CrowdFundingContext(DbContextOptions<CrowdFundingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Donation>()
                .Property(d => d.Status)
                .HasConversion<int>();
            builder.Entity<Project>()
                .Property(p => p.Status)
                .HasConversion<int>();
        }
    }
}
