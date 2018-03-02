using BlueCinema.Models;
using System;

namespace BlueCinema.Services.Interfaces
{
    public interface IBookingService : IService<Booking>
    {
        void Add(Guid seanceId, string places);
    }
}
