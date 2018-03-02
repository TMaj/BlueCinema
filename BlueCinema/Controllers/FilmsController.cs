using BlueCinema.Models;
using BlueCinema.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlueCinema.Controllers
{
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        public FilmsController(IFilmService filmService)
        {
            this.filmService = filmService;
        }

        IFilmService filmService;

        // GET api/films
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return filmService.GetAll();
        }

        // GET api/films/5
        [HttpGet("{id}")]
        public Film Get(Guid id)
        {
            return filmService.GetById(id);
        }

        // POST api/films
        [HttpPost]
        public void Post([FromBody]Film film)
        {
            filmService.Add(film);
        }

        // PUT api/films/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Film film)
        {
            filmService.Update(film);
        }

        // DELETE api/films/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            filmService.Remove(id);
        }
    }
}
