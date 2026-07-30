using DgtalVideo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DgtalVideo.Data
{
    public class WebContext : DbContext
    {
        public DbSet<PortfolioData> Portfolio { get; set; }
        public DbSet<ReviewsData> Reviews { get; set; }
        public DbSet<UserData> Users { get; set; }
        public DbSet<ContactFormData> ContactForm { get; set; }

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioData>()
                .HasOne(x => x.UserCreated)
                .WithMany(x => x.PortfolioMovies);

            modelBuilder.Entity<ReviewsData>()
                .HasOne(x => x.Users)
                .WithMany(x => x.Reviews);

            base.OnModelCreating(modelBuilder);
        }
    }
}