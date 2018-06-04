using System;

namespace BlueCinema.Models
{
    public class Booking
    {
        public Booking()
        {
        }

        public Booking(Seance seance, bool bought, string places) : this()
        {
            this.Seance = seance;
            this.Bought = bought;
            this.Places = places;
        }

        public Seance Seance { get; set; }
        public Guid Id { get; set; }
        public bool Bought { get; set; }
        public string Places { get; set; }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public DateTime BookingTime { get; set; }
    }
}
