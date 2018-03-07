using BlueCinema.Models;
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
}
