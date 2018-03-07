using BlueCinema.Models;
using System;
using System.Collections.Generic;

namespace BlueCinema.Tests.CinemaDataFactory
{
    public static class SeanceFactory
    {
        public static IList<Seance> GetSeance(Guid guid, int seatsNumber)
        {
            return new List<Seance>
            {
                new Seance
                {
                    Id = guid,
                    Room = RoomFactory.GetRoom(seatsNumber),
                    Film = FilmFactory.GetFilm(),
                    Bookings = new List<Booking>()
                }
            };
        }
    }

    public static class FilmFactory
    {
        public static Film GetFilm()
        {
            return new Film("Casablanca", 100, "Description");
        }
    }

    public static class RoomFactory
    {
        public static Room GetRoom()
        {
            return new Room(12, 100);
        }

        public static Room GetRoom(int seatsNumber)
        {
            return new Room(12, seatsNumber);
        }
    }

}

