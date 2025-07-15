using Microsoft.EntityFrameworkCore;
using FastX.DAL.Models;

namespace FastX.DAL
{
    public class FastXContext : DbContext
    {
        public FastXContext(DbContextOptions<FastXContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // You can configure relationships/constraints here if needed.
        }
    }
}
