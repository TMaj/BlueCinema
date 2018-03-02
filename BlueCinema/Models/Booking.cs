using System;

namespace BlueCinema.Models
{
    public class Booking
    {
        public Booking()
        {
        }

        public Seance Seance { get; set; }
        public Guid Id { get; set; }
        public bool Bought { get; set; }
        public string Places { get; set; }
    }
}
