using BlueCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace BlueCinema.Data
{
    public class BlueCinemaContext : DbContext
    {
        public BlueCinemaContext() : base()
        {

        }

        public BlueCinemaContext(DbContextOptions<BlueCinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
    }
}
