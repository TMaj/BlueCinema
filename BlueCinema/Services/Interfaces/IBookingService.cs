using BlueCinema.Models;
using BlueCinema.Models.Dto;
using System;
using System.Collections.Generic;

namespace BlueCinema.Services.Interfaces
{
    public interface IBookingService : IService<Booking>
    {
        string AddBooking(Booking booking);

        IList<Booking> GetByUserId(Guid id);
    }
}
