using BlueCinema.Models;
using System;

namespace BlueCinema.Tests.CinemaDataBuilder
{
    public class RoomBuilder
    {
        private Room room;

        public RoomBuilder()
        {
            this.room = new Room();
        }

        public RoomBuilder WithGuid(Guid guid)
        {
            this.room.Id = guid;
            return this;
        }

        public RoomBuilder WithNumber(int number)
        {
            this.room.RoomNumber = number;
            return this;
        }

        public RoomBuilder WithSeatsCount(int seatsCount)
        {
            this.room.SeatsCount = seatsCount;
            return this;
        }

        public Room Build()
        {
            return this.room;
        }
    }
}
