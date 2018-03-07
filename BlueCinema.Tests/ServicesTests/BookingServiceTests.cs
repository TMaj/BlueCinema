using BlueCinema.Services;
using BlueCinema.Tests.CinemaDataBuilder;
using System;

namespace BlueCinema.Tests.ServicesTests
{
    public class BookingServiceTests
    {
        private BookingService bookingService;
        private Guid seanceUid;
        private int seatsCount;

        public BookingServiceTests()
        {
            this.seanceUid = Guid.NewGuid();
            this.seatsCount = 100;
            var contextBuilder = new MockedDbContextBuilder();
            var mockedContext = contextBuilder
                .WithSeance(sb => sb
                    .WithGuid(seanceUid)
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
                        .WithPlaces("5:6:7")))
                 .Build();


            this.bookingService = new BookingService(mockedContext);
        }

        public void Adding_Valid_Booking_Should_Return_No_Exceptions()
        {

        }

        public void Adding_Booking_With_Already_Booked_Place_Should_Return_An_Exception()
        {

        }

        public void Adding_Booking_With_Invalid_Place_Number_Should_Return_An_Exception()
        {

        }

    }
}
