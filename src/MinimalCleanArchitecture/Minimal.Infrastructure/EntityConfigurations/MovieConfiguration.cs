using Microsoft.EntityFrameworkCore;
using Minimal.Core.Models;

namespace Minimal.Infrastructure.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(_ => _.Id);
        }
    }
}