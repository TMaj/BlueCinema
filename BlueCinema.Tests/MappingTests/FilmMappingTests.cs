using AutoMapper;
using BlueCinema.Models;
using BlueCinema.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlueCinema.Tests.MappingTests
{
    public class FilmMappingTests
    {
        private IMapper mapper;

        public FilmMappingTests()
        {
            this.mapper = MapperInstance.Instance;
        }

        [Fact]
        public void Mapping_Should_Return_Proper_Film()
        {
            var filmDto = new FilmDto { Id = Guid.NewGuid(), Duration = 100, Description = "abc", Title = "abc", Url = "abc" };

            var film = this.mapper.Map<Film>(filmDto);

            Assert.Equal(film.Id, filmDto.Id);
            Assert.Equal(film.Title, filmDto.Title);
            Assert.Equal(film.Duration, filmDto.Duration);
            Assert.Equal(film.Description, filmDto.Description);
            Assert.Equal(film.Url, filmDto.Url);
        }

        [Fact]
        public void Mapping_Should_Return_Proper_FilmDto()
        {
            var film = new Film { Id = Guid.NewGuid(), Duration = 100, Description = "abc", Title = "abc", Url = "abc" };

            var filmDto = this.mapper.Map<FilmDto>(film);

            Assert.Equal(film.Id, filmDto.Id);
            Assert.Equal(film.Title, filmDto.Title);
            Assert.Equal(film.Duration, filmDto.Duration);
            Assert.Equal(film.Description, filmDto.Description);
            Assert.Equal(film.Url, filmDto.Url);
        }
    }
}
