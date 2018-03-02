using BlueCinema.Models;
using BlueCinema.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlueCinema.Controllers
{
    [Route("api/[controller]")]
    public class SeancesController : Controller
    {
        public SeancesController(ISeanceService seanceService)
        {
            this.seanceService = seanceService;
        }

        ISeanceService seanceService;

        // GET api/seances
        [HttpGet]
        public IEnumerable<Seance> Get()
        {
            return seanceService.GetAll();
        }

        // GET api/seances/5
        [HttpGet("{id}")]
        public Seance Get(Guid id)
        {
            return seanceService.GetById(id);
        }

        // POST api/seances
        [HttpPost]
        public void Post([FromBody]Seance seance)
        {
            seanceService.Add(seance);
        }

        // PUT api/seances/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Seance seance)
        {
            seanceService.Update(seance);
        }

        // DELETE api/seances/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            seanceService.Remove(id);
        }
    }
}
