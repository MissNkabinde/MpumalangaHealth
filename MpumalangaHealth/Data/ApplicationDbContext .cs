using Microsoft.EntityFrameworkCore;
using MpumalangaHealth.Models;

namespace MpumalangaHealth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NewsItem> NewsItems { get; set; } = null!;
        public DbSet<Tender> Tenders { get; set; } = null!;  // Add this line

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NewsItem>()
                .Property(n => n.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<NewsItem>()
                .Property(n => n.PublishedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Tender>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Tender>()
                .Property(t => t.PublishedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}