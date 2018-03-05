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
            var intPlaces = ConversionHelper.ParseDelimitedStringToInts(':', places);
            var seance = this.context.Seances.FirstOrDefault(s => s.Id.Equals(seanceId));

            if (seance == null)
            {
                throw new Exception("Invalid seance id");
            }

            if (!IsBookingValid(seance, intPlaces))
            {
                throw new Exception("Invalid booking data. Perhaps places are already booked, or places numbers exceeds seats count.");
            };


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

        private bool IsBookingValid(Seance seance, IList<int> places)
        {
            if (places.Any(p => p < 0 || p > seance.Room.SeatsCount))
            {
                return false;
            }

            if (places.Any(p => seance.BookedPlaces.Contains(p)))
            {
                return false;
            }

            return true;

        }
    }
}
