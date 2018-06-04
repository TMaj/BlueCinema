using AutoMapper;
using BlueCinema.Models;
using BlueCinema.Tests.CinemaDataBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BlueCinema.Tests.MappingTests
{
    public class SeanceMappingTests
    {
        private IMapper mapper;

        public SeanceMappingTests()
        {
            this.mapper = MapperInstance.Instance;
        }

        [Fact]
        public void Mapping_Should_Return_Proper_Seance()
        {
            var seanceGuid = Guid.NewGuid();
            var bookingGuid = Guid.NewGuid();
            var filmGuid = Guid.NewGuid();
            var roomGuid = Guid.NewGuid();
            

            var seanceDtoBuilder = new SeanceDtoBuilder();
            var seanceDto = seanceDtoBuilder
                            .WithGuid(seanceGuid)
                            .WithTime(DateTime.Now)
                            .WithBooking(bookingDtoBuilder => bookingDtoBuilder
                                    .WithBoughtBool(true)
                                    .WithGuid(bookingGuid))
                            .WithFilm(filmDtoBuilder => filmDtoBuilder
                                    .WithGuid(filmGuid)
                                    .WithTitle("Film")
                                    .WithDuration(100)
                                    .WithDescription("aaa"))
                            .WithRoom(roomDtoBuilder => roomDtoBuilder
                                    .WithGuid(roomGuid)
                                    .WithNumber(10)
                                    .WithSeatsCount(100))
                            .Build();
            var seance = this.mapper.Map<Seance>(seanceDto);

            Assert.Equal(seanceDto.Id, seance.Id);
            Assert.Equal(seanceDto.Time, seance.Time.ToString());
            Assert.Equal(seanceDto.Bookings.FirstOrDefault().Bought, seance.Bookings.FirstOrDefault().Bought);
            Assert.Equal(seanceDto.Bookings.Count, seance.Bookings.Count);
            Assert.Equal(seanceDto.Room.Id, seance.Room.Id);
            Assert.Equal(seanceDto.Film.Id, seance.Film.Id);

        }

        //[Fact]
        //public void Mapping_Should_Return_Proper_SeanceDto()
        //{
        //}
    }
}
