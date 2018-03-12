using BlueCinema.Data;
using BlueCinema.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueCinema.Tests.CinemaDataBuilder
{
    public class MockedDbContextBuilder
    {
        private Mock<BlueCinemaContext> mockedContext;
        private IQueryable<Seance> seances;
        private IQueryable<Booking> bookings;

        public MockedDbContextBuilder()
        {
            this.mockedContext = new Mock<BlueCinemaContext>();
            this.SetupMockedSeances();
            this.SetupMockedBookings();
        }

        public BlueCinemaContext Build()
        {
            return mockedContext.Object;
        }

        public MockedDbContextBuilder WithSeance(Action<SeanceBuilder> seanceBuilderAction)
        {
            var seanceBuilder = new SeanceBuilder();
            seanceBuilderAction(seanceBuilder);
            this.seances = this.seances.Concat(new Seance[] { seanceBuilder.Build() });
            return this;
        }

        public MockedDbContextBuilder WithSeance(Seance seance)
        {
            this.seances = this.seances.Concat(new Seance[] { seance });
            return this;
        }

        private void SetupMockedSeances()
        {
            this.seances = new List<Seance>().AsQueryable();

            var mockSet = new Mock<DbSet<Seance>>();

            mockSet.As<IQueryable<Seance>>().Setup(m => m.Provider).Returns(this.seances.Provider);
            mockSet.As<IQueryable<Seance>>().Setup(m => m.Expression).Returns(this.seances.Expression);
            mockSet.As<IQueryable<Seance>>().Setup(m => m.ElementType).Returns(this.seances.ElementType);
            mockSet.As<IQueryable<Seance>>().Setup(m => m.GetEnumerator()).Returns(() => this.seances.GetEnumerator());

            mockedContext.Setup(c => c.Seances).Returns(mockSet.Object);
            mockedContext.Setup(c => c.Set<Seance>()).Returns(mockSet.Object);
        }

        private void SetupMockedBookings()
        {
            this.bookings = new List<Booking>().AsQueryable();

            var mockSet = new Mock<DbSet<Booking>>();

            mockSet.As<IQueryable<Booking>>().Setup(m => m.Provider).Returns(this.bookings.Provider);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Expression).Returns(this.bookings.Expression);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.ElementType).Returns(this.bookings.ElementType);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.GetEnumerator()).Returns(() => this.bookings.GetEnumerator());

            mockedContext.Setup(c => c.Bookings).Returns(mockSet.Object);
        }
    }
}
