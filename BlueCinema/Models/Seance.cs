using BlueCinema.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Models
{
    public class Seance
    {
        public Seance()
        {

        }

        public Seance(DateTime time, Room room, Film film)
        {
            Time = time;
            Room = room;
            Film = film;
        }

        public IList<int> BookedPlaces => ConversionHelper.ParseDelimitedStringsToInts(':', Bookings.Select(b => b.Places).ToList());

        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public Room Room { get; set; }
        public Film Film { get; set; }
        public List<Booking> Bookings { get; set; }
    }

}
