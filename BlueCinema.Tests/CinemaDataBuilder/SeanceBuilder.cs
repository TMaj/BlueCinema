using BlueCinema.Models;
using BlueCinema.Models.Dto;
using System;

namespace BlueCinema.Tests.CinemaDataBuilder
{
    public class SeanceBuilder
    {
        private Seance seance;

        public SeanceBuilder()
        {
            this.seance = new Seance();
        }

        public SeanceBuilder WithGuid(Guid guid)
        {
            this.seance.Id = guid;
            return this;
        }

        public SeanceBuilder WithTime(DateTime time)
        {
            this.seance.Time = time;
            return this;
        }

        public SeanceBuilder WithRoom(Action<RoomBuilder> roomBuilderAction)
        {
            var roomBuilder = new RoomBuilder();
            roomBuilderAction(roomBuilder);
            this.seance.Room = roomBuilder.Build();
            return this;
        }

        public SeanceBuilder WithFilm(Action<FilmBuilder> filmBuilderAction)
        {
            var filmBuilder = new FilmBuilder();
            filmBuilderAction(filmBuilder);
            this.seance.Film = filmBuilder.Build();
            return this;
        }

        public SeanceBuilder WithBooking(Action<BookingBuilder> bookingBuilderAction)
        {
            var bookingBuilder = new BookingBuilder(this.seance);
            bookingBuilderAction(bookingBuilder);
            this.seance.Bookings.Add(bookingBuilder.Build());
            return this;
        }

        public Seance Build()
        {
            return this.seance;
        }
    }

    public class SeanceDtoBuilder
    {
        private SeanceDto seanceDto;

        public SeanceDtoBuilder()
        {
            this.seanceDto = new SeanceDto();
        }

        public SeanceDtoBuilder WithGuid(Guid guid)
        {
            this.seanceDto.Id = guid;
            return this;
        }

        public SeanceDtoBuilder WithTime(DateTime time)
        {
            this.seanceDto.Time = time.ToString();
            return this;
        }

        public SeanceDtoBuilder WithRoom(Action<RoomDtoBuilder> roomBuilderAction)
        {
            var roomDtoBuilder = new RoomDtoBuilder();
            roomBuilderAction(roomDtoBuilder);
            this.seanceDto.Room = roomDtoBuilder.Build();
            return this;
        }

        public SeanceDtoBuilder WithFilm(Action<FilmDtoBuilder> filmBuilderAction)
        {
            var filmDtoBuilder = new FilmDtoBuilder();
            filmBuilderAction(filmDtoBuilder);
            this.seanceDto.Film = filmDtoBuilder.Build();
            return this;
        }

        public SeanceDtoBuilder WithBooking(Action<BookingDtoBuilder> bookingBuilderAction)
        {
            var bookingDtoBuilder = new BookingDtoBuilder(this.seanceDto);
            bookingBuilderAction(bookingDtoBuilder);
            this.seanceDto.Bookings.Add(bookingDtoBuilder.Build());
            return this;
        }

        public SeanceDto Build()
        {
            return this.seanceDto;
        }
    }
}
