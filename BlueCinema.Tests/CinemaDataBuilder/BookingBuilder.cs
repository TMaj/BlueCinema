using BlueCinema.Models;
using System;

namespace BlueCinema.Tests.CinemaDataBuilder
{
    public class BookingBuilder
    {
        private Booking booking;

        public BookingBuilder(Seance seance)
        {
            this.booking = new Booking();
            this.booking.Seance = seance;
        }

        public BookingBuilder WithGuid(Guid guid)
        {
            this.booking.Id = guid;
            return this;
        }

        public BookingBuilder WithBoughtBool(bool bought)
        {
            this.booking.Bought = bought;
            return this;
        }

        public BookingBuilder WithPlaces(string places)
        {
            this.booking.Places = places;
            return this;
        }

        public Booking Build()
        {
            return this.booking;
        }
    }
}
