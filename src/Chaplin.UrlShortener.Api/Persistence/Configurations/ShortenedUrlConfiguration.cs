using Chaplin.UrlShortener.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chaplin.UrlShortener.Api.Persistence.Configurations
{
    public class ShortenedUrlConfiguration : IEntityTypeConfiguration<ShortenedUrl>
    {
        public void Configure(EntityTypeBuilder<ShortenedUrl> builder)
        {
            // Define table name
            builder.ToTable("ShortenedUrls");

            // Define primary key
            builder.HasKey(su => su.Id);

            builder.Property(e => e.OriginalUrl).IsRequired().HasMaxLength(2048);
            builder.Property(e => e.ShortCode).IsRequired().HasMaxLength(20);
            builder.HasIndex(e => e.ShortCode).IsUnique();

            // Configure Created and LastModified properties to be handled as immutable and modifiable timestamps
            builder.Property(su => su.Created)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(su => su.LastModified)
                   .IsRequired()
                   .ValueGeneratedOnUpdate();
        }
    }
}