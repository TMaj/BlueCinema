using BlueCinema.Data;
using BlueCinema.Exceptions;
using BlueCinema.Helpers;
using BlueCinema.Models;
using BlueCinema.Models.Dto;
using BlueCinema.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public string AddBooking(Booking booking)
        {
            this.Add(booking);
            return booking.Id.ToString().Substring(0, 8);
        }

        public void Add(Booking booking)
        {
            var seance = this.context.Seances.Include(s => s.Film)
                                 .Include(s => s.Bookings)
                                 .Include(s => s.Room)
                                 .ToList().FirstOrDefault(s => s.Id.Equals(booking.Seance.Id));

            booking.Seance = seance ?? throw new BookingException("Invalid seance id");

            ValidateBooking(booking);

            booking.BookingTime = DateTime.Now;

            context.Bookings.Add(booking);
            context.SaveChanges();
        }

        public IList<Booking> GetAll()
        {
            return context.Bookings
                           .Include(b => b.Seance)
                           .ToList();
        }

        public Booking GetById(Guid id)
        {
           return context.Bookings.FirstOrDefault(b => b.Id == id);
        }       

        public void Remove(Guid id)
        {
            if (context.Bookings.FirstOrDefault(b => b.Id == id) == null)
            {
                return;
            }              
            context.Bookings.Remove(context.Bookings.FirstOrDefault(b => b.Id == id));
            context.SaveChanges();
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

            if (places.Any(p => ConversionHelper.ParseDelimitedStringsToInts(':', seance.Bookings.Select(b => b.Places).ToList()).Contains(p))) 
            {
                return false;
            }

            return true;
        }

        public IList<Booking> GetByUserId(Guid id)
        {
           return GetAll().Where(b => b.UserId.Equals(id)).OrderByDescending(b=> b.BookingTime).ToList();
        }
    }
}
