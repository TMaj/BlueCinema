using AutoMapper;
using BlueCinema.Models;
using BlueCinema.Models.Dto;
using BlueCinema.Models.ViewModels;
using BlueCinema.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlueCinema.Controllers
{
    [Route("api/[controller]")]
    public class BookingsController : Controller
    {
        private IMapper mapper; 

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {            
            this.bookingService = bookingService;
            this.mapper = mapper;
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
        public BookingDto Get(Guid id)
        {
            return this.mapper.Map<BookingDto>(bookingService.GetById(id));
        }

        // GET api/bookings/5
        [HttpGet("user/{id}")]
        public IList<BookingDto> GetByUserId(Guid id)
        {
            return this.mapper.Map<IList<BookingDto>>(bookingService.GetByUserId(id));
        }

        // POST api/bookings
        [HttpPost]
        public string Post([FromBody]BookingDto booking) 
        {           
           return  bookingService.AddBooking(this.mapper.Map<Booking>(booking));
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
