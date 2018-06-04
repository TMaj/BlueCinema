using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCinema.Models.Dto
{
    public class SeanceDto
    {
        public SeanceDto()
        {
            this.Bookings = new List<BookingDto>();
        }
               
        public Guid Id { get; set; }
        public string Time { get; set; }
        public RoomDto Room { get; set; }
        public FilmDto Film { get; set; }
        public List<BookingDto> Bookings { get; set; }

        public List<int> BookedPlaces => this.Bookings.SelectMany(b => b.BookedPlaces).ToList();
    }
}
