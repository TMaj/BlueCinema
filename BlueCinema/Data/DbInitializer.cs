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

            var film1 = new Film("Quo Vadis", 90, "A movie about ancient Rome", "qv.jpg");
            var film2 = new Film("Spiderman", 120, "Adventures of a famous hero", "sd.jpg");
            var film3 = new Film("Silence of the Lambs", 110, "Horrifying story about serial killer", "sl.jpg");
            var film4 = new Film("Avatar", 80, "Futuristic tales about blue civilization", "av.jpg");
            var film5 = new Film("Private Rayan", 150, "Touching history of a lost soldier", "pr.jpg");
            var film6 = new Film("Troy", 90, "Famous clash between Greeks and Toyans", "tr.jpg");
            var film7 = new Film("Wolf of Wallstreet", 100, "Leonardo Dicaprio in a terrific role", "ww.jpg");
            var film8 = new Film("Matrix", 110, "Keanu Reaves fights armies of enemies on his own", "mt.jpg");

            var room1 = new Room(1, 160);
            var room2 = new Room(2, 160);
            var room3 = new Room(3, 160);
            var room4 = new Room(4, 160);
            var room5 = new Room(5, 160);
            var room6 = new Room(6, 160);

            var seance1 = new Seance(new DateTime(2018, 6, 4, 14, 30, 0), room1, film1);
            var seance1_5 = new Seance(new DateTime(2018, 6, 4, 18, 30, 0), room1, film1);
            var seance2 = new Seance(new DateTime(2018, 6, 4, 10, 30, 0), room2, film2);
            var seance2_2 = new Seance(new DateTime(2018, 6, 4, 12, 30, 0), room2, film2);
            var seance2_3 = new Seance(new DateTime(2018, 6, 4, 15, 30, 0), room2, film2);
            var seance2_4 = new Seance(new DateTime(2018, 6, 4, 18, 30, 0), room2, film2);
            var seance2_5 = new Seance(new DateTime(2018, 6, 4, 20, 00, 0), room2, film3);
            var seance2_6 = new Seance(new DateTime(2018, 6, 4, 12, 00, 0), room2, film7);
            var seance2_7 = new Seance(new DateTime(2018, 6, 4, 10, 00, 0), room3, film7);
            var seance2_8 = new Seance(new DateTime(2018, 6, 4, 8, 00, 0), room4, film7);
            var seance2_9 = new Seance(new DateTime(2018, 6, 4, 20, 00, 0), room1, film8);

            var seance3 = new Seance(new DateTime(2018, 6, 4, 16, 30, 0), room3, film3);
            var seance4 = new Seance(new DateTime(2018, 6, 5, 17, 30, 0), room4, film4);
            var seance5 = new Seance(new DateTime(2018, 6, 5, 14, 30, 0), room1, film1);
            var seance6 = new Seance(new DateTime(2018, 6, 5, 15, 30, 0), room2, film2);
            var seance7 = new Seance(new DateTime(2018, 6, 5, 16, 30, 0), room3, film3);
            var seance8 = new Seance(new DateTime(2018, 6, 6, 17, 30, 0), room4, film7);
            var seance9 = new Seance(new DateTime(2018, 6, 6, 17, 30, 0), room4, film7);
            var seance10 = new Seance(new DateTime(2018, 6, 7, 17, 30, 0), room4, film5);
            var seance11 = new Seance(new DateTime(2018, 6, 7, 17, 30, 0), room4, film8);
            var seance12 = new Seance(new DateTime(2018, 6, 8, 17, 30, 0), room4, film8);

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
                    seance1_5,
                    seance2,
                    seance2_2,
                    seance2_3,
                    seance2_4,
                    seance2_5,
                    seance2_6,
                    seance2_7,
                    seance2_8,
                    seance2_9,
                    seance3,
                    seance4,
                    seance5,
                    seance6,
                    seance7,
                    seance8,
                    seance9,
                    seance10,
                    seance11,
                    seance12
                };

                seances.ForEach(s => context.Seances.Add(s));
                context.SaveChanges();
            }
        }
    }
}
