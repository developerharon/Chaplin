using Chaplin.UrlShortener.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Chaplin.UrlShortener.Api.Persistence
{
    public class ShortenedUrlDbContext(DbContextOptions<ShortenedUrlDbContext> options) : DbContext(options)
    {
        public DbSet<ShortenedUrl> ShortenedUrls => Set<ShortenedUrl>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("app");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShortenedUrlDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}