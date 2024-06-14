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
    }
}
