using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueCinema.Models.Dto
{
    public class FilmDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
