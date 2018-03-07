using BlueCinema.Models;
using System;

namespace BlueCinema.Tests.CinemaDataBuilder
{
    public class FilmBuilder
    {
        private Film film;

        public FilmBuilder()
        {
            this.film = new Film();
        }

        public FilmBuilder WithGuid(Guid guid)
        {
            this.film.Id = guid;
            return this;
        }

        public FilmBuilder WithTitle(string title)
        {
            this.film.Title = title;
            return this;
        }

        public FilmBuilder WithDuration(int duration)
        {
            this.film.Duration = duration;
            return this;
        }

        public FilmBuilder WithDescription(string description)
        {
            this.film.Description = description;
            return this;
        }

        public Film Build()
        {
            return this.film;
        }

    }
}
