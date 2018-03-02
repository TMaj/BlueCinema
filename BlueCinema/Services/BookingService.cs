using BlueCinema.Data;
using BlueCinema.Helpers;
using BlueCinema.Models;
using BlueCinema.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Services
{
    public class BookingService : IBookingService
    {
        BlueCinemaContext context;

        public BookingService(BlueCinemaContext context)
        {
            this.context = context;
        }

        public void Add(Booking booking)
        {
            context.Bookings.Add(booking);
        }

        public void Add(Guid seanceId, string places)
        {
            var intPlaces = ConversionHelper.ParseDelimitedStringToInts(":",places); 

        }

        public IList<Booking> GetAll()
        {
            return context.Bookings.ToList();
        }

        public Booking GetById(Guid id)
        {
            return context.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public void Remove(Guid id)
        {
            context.Bookings.Remove(context.Bookings.FirstOrDefault(b => b.Id == id));
        }

        public void Update(Booking booking)
        {
            var oldBooking = context.Bookings.FirstOrDefault(b => b.Id == booking.Id);
            oldBooking = booking;
            context.SaveChanges();
        }
    }
}
