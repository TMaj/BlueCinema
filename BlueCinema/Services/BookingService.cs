using BlueCinema.Data;
using BlueCinema.Exceptions;
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
            ValidateBooking(booking);

            context.Bookings.Add(booking);
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

        private void ValidateBooking(Booking booking)
        {
            var intPlaces = ConversionHelper.ParseDelimitedStringToInts(':', booking.Places);

            if (booking.Seance == null)
            {
                throw new BookingException("Booking has no seance reference");
            }

            var seance = this.context.Seances.ToList().FirstOrDefault(s => s.Id.Equals(booking.Seance.Id));

            if (seance == null)
            {
                throw new BookingException("Invalid seance id");
            }

            if (!AreBookingPlacesValid(seance, intPlaces))
            {
                throw new BookingException("Invalid booking data. Perhaps places are already booked, or places numbers exceeds seats count.");
            }
        }

        private bool AreBookingPlacesValid(Seance seance, IList<int> places)
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
