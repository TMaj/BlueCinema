using BlueCinema.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCinema.Models.Dto
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid SeanceId { get; set; }
        public bool Bought { get; set; }
        public IList<int> BookedPlaces { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string BookingTime { get; set; }
    }
}
