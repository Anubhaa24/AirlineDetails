using AirlineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineAPI.Data
{
    public class AirlineAPIDbContext : DbContext
    {
        public AirlineAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Airline> Airlines { get; set; }
    }
}
