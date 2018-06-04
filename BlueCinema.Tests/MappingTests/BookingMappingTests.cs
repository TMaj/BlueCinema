using AutoMapper;
using BlueCinema.Helpers;
using BlueCinema.Models;
using BlueCinema.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlueCinema.Tests.MappingTests
{
    public class BookingMappingTests
    {
        private IMapper mapper;

        public BookingMappingTests()
        {
            this.mapper = MapperInstance.Instance;
        }

        [Fact]
        public void Mapping_Should_Return_Proper_Booking_Dto()
        {
            var seanceId = Guid.NewGuid();

            var booking = new Booking() { Id = Guid.NewGuid(), Bought = true, Places = "1:2:3", Seance = new Seance { Id = seanceId } };

            var bookingDto = this.mapper.Map<BookingDto>(booking);

            Assert.Equal(booking.Id, bookingDto.Id);
            Assert.Equal(booking.Seance.Id, bookingDto.SeanceId);
            Assert.Equal(booking.Places, ConversionHelper.ParseIntsToDelimitedString(':', bookingDto.BookedPlaces));
            Assert.Equal(booking.Bought, bookingDto.Bought);
        }

        [Fact]
        public void Mapping_Should_Return_Proper_Booking()
        {
            var seanceId = Guid.NewGuid();

            var bookingDto = new BookingDto() { Id = Guid.NewGuid(), Bought = true, BookedPlaces = new List<int> { 1,2,3 }, SeanceId = seanceId };

            var booking = this.mapper.Map<Booking>(bookingDto);

            Assert.Equal(booking.Id, bookingDto.Id);
            Assert.Equal(booking.Seance.Id, bookingDto.SeanceId);
            Assert.Equal(booking.Places, ConversionHelper.ParseIntsToDelimitedString(':', bookingDto.BookedPlaces));
            Assert.Equal(booking.Bought, bookingDto.Bought);
        }
    }
}
