using BlueCinema.Models;
using BlueCinema.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlueCinema.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        IBookingService bookingService;

        // GET api/bookings
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return bookingService.GetAll();
        }

        // GET api/bookings/5
        [HttpGet("{id}")]
        public Booking Get(Guid id)
        {
            return bookingService.GetById(id);
        }

        // POST api/bookings
        [HttpPost]
        public void Post([FromBody]Guid seanceId, string places)
        {
            
        }

        // PUT api/bookings/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Booking booking)
        {
            bookingService.Update(booking);
        }

        // DELETE api/bookings/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            bookingService.Remove(id);
        }
    }
}
