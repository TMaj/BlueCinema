using BlueCinema.Data;
using BlueCinema.Models;
using BlueCinema.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Services
{
    public class FilmService : IFilmService
    {
        BlueCinemaContext context;

        public FilmService(BlueCinemaContext context)
        {
            this.context = context;
        }
        
        public void Add(Film film)
        {
            context.Films.Add(film);
        }

        public IList<Film> GetAll()
        {
           return context.Films.ToList();
        }

        public Film GetById(Guid id)
        {
            return context.Films.FirstOrDefault(f => f.Id == id);
        }

        public void Remove(Guid id)
        {
            context.Films.Remove(context.Films.FirstOrDefault(f => f.Id == id));
        }

        public void Update(Film film)
        {
            var oldFilm = context.Films.FirstOrDefault(f => f.Id == film.Id);
            oldFilm = film;
            context.SaveChanges();
        }
    }
}
