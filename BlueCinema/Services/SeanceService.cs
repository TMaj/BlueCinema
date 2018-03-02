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
            return context.Seances.FirstOrDefault(s => s.Id == id);
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
