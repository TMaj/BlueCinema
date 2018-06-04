using AutoMapper;
using BlueCinema.Models;
using BlueCinema.Models.Dto;
using BlueCinema.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlueCinema.Controllers
{
    [Route("api/[controller]")]
    public class SeancesController : Controller
    {
        private IMapper mapper;

        public SeancesController(ISeanceService seanceService, IMapper mapper)
        {
            this.seanceService = seanceService;
            this.mapper = mapper;
        }

        ISeanceService seanceService;

        // GET api/seances
        [HttpGet]
        public IEnumerable<SeanceDto> Get()
        {
            return mapper.Map<IList<SeanceDto>>(seanceService.GetAll());
        }

        // GET api/seances/5
        [HttpGet("{id}")]
        public SeanceDto Get(Guid id)
        {
            return this.mapper.Map<SeanceDto>(seanceService.GetById(id));
        }

        [HttpGet("time")]
        public IList<(Guid seanceId, Guid filmUid, IList<DateTime> dates)> GetSeancesWithTimes([FromQuery(Name = "seanceDate")]DateTime seanceDate, [FromQuery(Name = "filmId")] Guid filmId)
        {
            return seanceService.GetSeancesWithTimes(seanceDate);
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
