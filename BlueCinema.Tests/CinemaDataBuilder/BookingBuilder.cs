using BlueCinema.Models;
using BlueCinema.Models.Dto;
using System;
using System.Collections.Generic;

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

public class BookingDtoBuilder
{
    private BookingDto bookingDto;

    public BookingDtoBuilder(SeanceDto seanceDto)
    {
        this.bookingDto = new BookingDto();
        this.bookingDto.SeanceId = seanceDto.Id;
    }

    public BookingDtoBuilder WithGuid(Guid id)
    {
        this.bookingDto.Id = id;
        return this;
    }

    public BookingDtoBuilder WithBoughtBool(bool bought)
    {
        this.bookingDto.Bought = bought;
        return this;
    }

    public BookingDtoBuilder WithPlaces(IList<int> bookedPlaces)
    {
        this.bookingDto.BookedPlaces = bookedPlaces;
        return this;
    }

    public BookingDto Build()
    {
        return this.bookingDto;
    }
}