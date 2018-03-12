using BlueCinema.Exceptions;
using BlueCinema.Models;
using BlueCinema.Services;
using BlueCinema.Tests.CinemaDataBuilder;
using System;
using Xunit;

namespace BlueCinema.Tests.ServicesTests
{
    public class BookingServiceTests
    {
        private BookingService bookingService;
        private Seance seance;
        private int seatsCount;

        public BookingServiceTests()
        {
            this.seatsCount = 100;

            this.seance = new SeanceBuilder()
                .WithGuid(Guid.NewGuid())
                .WithTime(new DateTime(2018, 03, 10, 12, 00, 00))
                .WithFilm(fb => fb
                    .WithGuid(Guid.NewGuid())
                    .WithTitle("Pan Tadeusz")
                    .WithDescription("Fascinating novel")
                    .WithDuration(120))
                .WithRoom(rb => rb
                    .WithGuid(Guid.NewGuid())
                    .WithNumber(1)
                    .WithSeatsCount(seatsCount))
                .WithBooking(bb => bb
                    .WithGuid(Guid.NewGuid())
                    .WithBoughtBool(true)
                    .WithPlaces("1:2:3:4"))
                .WithBooking(bb => bb
                    .WithGuid(Guid.NewGuid())
                    .WithBoughtBool(true)
                    .WithPlaces("5:6:7"))
                .Build();

            var contextBuilder = new MockedDbContextBuilder();
            var mockedContext = contextBuilder
                .WithSeance(seance)
                .Build();


            this.bookingService = new BookingService(mockedContext);
        }

        [Fact]
        public void Adding_Valid_Booking_Should_Return_No_Exceptions()
        {

            var booking = new BookingBuilder(this.seance)
                              .WithGuid(Guid.NewGuid())
                              .WithBoughtBool(true)
                              .WithPlaces("8:9:10:11")
                              .Build();

            bookingService.Add(booking);

        }

        [Fact]
        public void Adding_Booking_With_Already_Booked_Place_Should_Return_An_BookingException()
        {
            var booking = new BookingBuilder(this.seance)
                              .WithGuid(Guid.NewGuid())
                              .WithBoughtBool(true)
                              .WithPlaces("1")
                              .Build();

            Assert.Throws(typeof(BookingException), () => bookingService.Add(booking));
        }

        [Fact]
        public void Adding_Booking_With_Invalid_Place_Number_Should_Return_An_BookingException()
        {
            var booking = new BookingBuilder(this.seance)
                             .WithGuid(Guid.NewGuid())
                             .WithBoughtBool(true)
                             .WithPlaces($"{this.seatsCount + 1}")
                             .Build();

            Assert.Throws(typeof(BookingException), () => bookingService.Add(booking));
        }

    }
}
