using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCinema.Models.Dto
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public int SeatsCount { get; set; }
    }
}
