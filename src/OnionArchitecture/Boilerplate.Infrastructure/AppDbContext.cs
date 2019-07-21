using System;
using Boilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = Guid.Parse("3550680d-8530-4a0d-8712-43845be8a129"),
                    Name = "Godfather",
                    Rating = 4.5
                }
            );
        }
    }
}