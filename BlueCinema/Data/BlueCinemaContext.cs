using BlueCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueCinema.Data
{
    public class BlueCinemaContext : DbContext
    {
        public BlueCinemaContext(DbContextOptions<BlueCinemaContext> options)
            : base(options)
        {
        }
        
        public DbSet<Film> Films { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
