using BlueCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BlueCinemaContext context)
        {
            context.Database.EnsureCreated();

            var film1 = new Film("Quo Vadis", 90, "A movie about ancient Rome");
            var film2 = new Film("Spiderman", 120, "Adventures of a famous hero");
            var film3 = new Film("Silence of the Lambs", 110, "Horrifying story about serial killer");
            var film4 = new Film("Avatar", 80, "Futuristic tales about blue civilization");
            var film5 = new Film("Private Rayan", 150, "Touching history of a lost soldier");
            var film6 = new Film("Troy", 90, "Famous clash between Greeks and Toyans");
            var film7 = new Film("Wolf of Wallstreet", 100, "Leonardo Dicaprio in a terrific role");
            var film8 = new Film("Matrix", 110, "Keanu Reaves fights armies of enemies on his own");

            var room1 = new Room(1, 60);
            var room2 = new Room(2, 50);
            var room3 = new Room(3, 70);
            var room4 = new Room(4, 80);
            var room5 = new Room(5, 80);
            var room6 = new Room(6, 60);

            var seance1 = new Seance(new DateTime(2018, 3, 15, 14, 30, 0), room1, film1);
            var seance2 = new Seance(new DateTime(2018, 3, 15, 15, 30, 0), room2, film2);
            var seance3 = new Seance(new DateTime(2018, 3, 15, 16, 30, 0), room3, film3);
            var seance4 = new Seance(new DateTime(2018, 3, 15, 17, 30, 0), room4, film4);
            var seance5 = new Seance(new DateTime(2018, 3, 16, 14, 30, 0), room1, film1);
            var seance6 = new Seance(new DateTime(2018, 3, 16, 15, 30, 0), room2, film2);
            var seance7 = new Seance(new DateTime(2018, 3, 16, 16, 30, 0), room3, film3);
            var seance8 = new Seance(new DateTime(2018, 3, 16, 17, 30, 0), room4, film4);

            if (!context.Films.Any())
            {
                var films = new List<Film>
                {
                    film1,
                    film2,
                    film3,
                    film4,
                    film5,
                    film6,
                    film7,
                    film8
                };

                films.ForEach(f => context.Add(f));
                context.SaveChanges();
            }

            if (!context.Rooms.Any())
            {
                var rooms = new List<Room>
                {
                    room1,
                    room2,
                    room3,
                    room4,
                    room5,
                    room6
                };

                rooms.ForEach(r => context.Rooms.Add(r));
                context.SaveChanges();
            }

            if (!context.Seances.Any())
            {
                var seances = new List<Seance>()
                {
                    seance1,
                    seance2,
                    seance3,
                    seance4,
                    seance5,
                    seance6,
                    seance7,
                    seance8,
                };

                seances.ForEach(s => context.Seances.Add(s));
                context.SaveChanges();
            }            
        }
    }
}
