using BlueCinema.Data;
using BlueCinema.Models;
using BlueCinema.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Services
{
    public class SeanceService : ISeanceService
    {
        BlueCinemaContext context;

        public SeanceService(BlueCinemaContext context)
        {
            this.context = context;
        }

        public void Add(Seance seance)
        {
            context.Seances.Add(seance);
        }

        public IList<Seance> GetAll()
        {
            return context.Seances.Include(s => s.Film)
                                  .Include(s => s.Bookings)
                                  .Include(s => s.Room)
                                  .ToList();
        }

        public Seance GetById(Guid id)
        {
            return this.GetAll().FirstOrDefault(s => s.Id == id);
        }

        public IList<(Guid seanceId, Guid filmId, IList<DateTime> time)> GetSeancesWithTimes(DateTime seanceDate)
        {
            var seances = this.GetAll().Where(s => s.Time.Day.Equals(seanceDate.Day) && s.Time.Month.Equals(seanceDate.Month));
            var films = seances.Select(s => s.Film).Distinct().ToList();
            var returnList = new List<(Guid, Guid, IList<DateTime>)>();
            films.ForEach(f => returnList.Add((seanceId: seances.FirstOrDefault(s => s.Film.Id.Equals(f.Id)).Id, filmId: f.Id, time: seances.Where(s => s.Film.Id.Equals(f.Id)).Select(s => s.Time).ToList())));
            return returnList;
        }

        public IList<DateTime> GetSeanceTimes(DateTime seanceDate, Guid filmId)
        {
            return GetAll().Where(s => s.Film.Id.Equals(filmId) && s.Time.Day.Equals(seanceDate.Day) && s.Time.Month.Equals(seanceDate.Month))
                          .Select(s => s.Time)
                          .ToList();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Seance seance)
        {
            throw new System.NotImplementedException();
        }
    }
}
