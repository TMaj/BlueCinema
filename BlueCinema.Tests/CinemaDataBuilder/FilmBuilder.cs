using BlueCinema.Models;
using BlueCinema.Models.Dto;
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

    public class FilmDtoBuilder
    {
        private FilmDto filmDto;

        public FilmDtoBuilder()
        {
            this.filmDto = new FilmDto();
        }

        public FilmDtoBuilder WithGuid(Guid guid)
        {
            this.filmDto.Id = guid;
            return this;
        }

        public FilmDtoBuilder WithTitle(string title)
        {
            this.filmDto.Title = title;
            return this;
        }

        public FilmDtoBuilder WithDuration(int duration)
        {
            this.filmDto.Duration = duration;
            return this;
        }

        public FilmDtoBuilder WithDescription(string description)
        {
            this.filmDto.Description = description;
            return this;
        }

        public FilmDto Build()
        {
            return this.filmDto;
        }
    }
}
