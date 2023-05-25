using Microsoft.EntityFrameworkCore;

namespace Flyhigh_Airlines.Models
{
    public class FlyhighContext:DbContext
    {
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public FlyhighContext(DbContextOptions<FlyhighContext> options) : base(options) { }
    }
}
