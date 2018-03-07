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

        public MockedDbContextBuilder()
        {
            this.mockedContext = new Mock<BlueCinemaContext>();
            this.seances = new List<Seance>().AsQueryable();
        }

        public BlueCinemaContext Build()
        {
            return mockedContext.Object;
        }

        public MockedDbContextBuilder WithSeance(Action<SeanceBuilder> seanceBuilderAction)
        {
            var seanceBuilder = new SeanceBuilder();
            seanceBuilderAction(seanceBuilder);
            this.seances.ToList().Add(seanceBuilder.Build());

            var mockSet = new Mock<DbSet<Seance>>();

            mockSet.As<IQueryable<Seance>>().Setup(m => m.Provider).Returns(this.seances.Provider);
            mockSet.As<IQueryable<Seance>>().Setup(m => m.Expression).Returns(this.seances.Expression);
            mockSet.As<IQueryable<Seance>>().Setup(m => m.ElementType).Returns(this.seances.ElementType);
            mockSet.As<IQueryable<Seance>>().Setup(m => m.GetEnumerator()).Returns(this.seances.GetEnumerator());

            mockedContext.Setup(c => c.Seances).Returns(mockSet.Object);

            return this;
        }
    }
}
