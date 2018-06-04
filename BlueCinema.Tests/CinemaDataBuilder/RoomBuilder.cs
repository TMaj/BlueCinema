using BlueCinema.Models;
using BlueCinema.Models.Dto;
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

    public class RoomDtoBuilder
    {
        private RoomDto roomDto;

        public RoomDtoBuilder()
        {
            this.roomDto = new RoomDto();
        }

        public RoomDtoBuilder WithGuid(Guid guid)
        {
            this.roomDto.Id = guid;
            return this;
        }

        public RoomDtoBuilder WithNumber(int number)
        {
            this.roomDto.RoomNumber = number;
            return this;
        }

        public RoomDtoBuilder WithSeatsCount(int seatsCount)
        {
            this.roomDto.SeatsCount = seatsCount;
            return this;
        }

        public RoomDto Build()
        {
            return this.roomDto;
        }
    }
}
