using System;

namespace BlueCinema.Models
{
    public class Film
    {
        public Film()
        {

        }

        public Film(string title, int duration, string description)
        {
            Title = title;
            Duration = duration;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}
