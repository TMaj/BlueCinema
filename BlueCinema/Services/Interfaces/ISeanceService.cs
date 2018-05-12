using BlueCinema.Models;
using System;
using System.Collections.Generic;

namespace BlueCinema.Services.Interfaces
{
    public interface ISeanceService : IService<Seance>
    {
        IList<DateTime> GetSeanceTimes(DateTime seanceDate, Guid filmId);
        IList<(Guid filmId, IList<DateTime> time)> GetSeancesWithTimes(DateTime seanceDate);
    }
}
