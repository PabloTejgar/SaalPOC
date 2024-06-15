using Microsoft.EntityFrameworkCore;
using Saal.API.Models;

namespace Saal.API.Data
{
    /// <summary>
    /// Saal db context.
    /// </summary>

    public class SaalContext : DbContext
    {
        /// <summary>
        /// Saal db context.
        /// </summary>
        /// <param name="options">options to initialize.</param>
        public SaalContext(DbContextOptions<SaalContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Restaurant db set.
        /// </summary>
        public DbSet<Restaurant> Restaurant { get; set; }

        /// <summary>
        /// City db set.
        /// </summary>
        public DbSet<City> City { get; set; }

        /// <summary>
        /// OnModelCreating override method.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "León"  },
                new City { Id = 2, Name = "London" },
                new City { Id = 3, Name = "Berlin" },
                new City { Id = 4, Name = "Rome" }
                );
        }

    }
}
