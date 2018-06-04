using AutoMapper;
using BlueCinema.Models;
using BlueCinema.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BlueCinema.Tests.MappingTests
{
    public class RoomMappingTests
    {
        private IMapper mapper;

        public RoomMappingTests()
        {
            this.mapper = MapperInstance.Instance;
        }

        [Fact]
        public void Mapping_Should_Return_Proper_Room()
        {
            var roomDto = new RoomDto { Id = Guid.NewGuid(), RoomNumber = 10, SeatsCount = 100 };

            var room = this.mapper.Map<Room>(roomDto);

            Assert.Equal(room.Id, roomDto.Id);
            Assert.Equal(room.RoomNumber, roomDto.RoomNumber);
            Assert.Equal(room.SeatsCount, roomDto.SeatsCount);
        }

        [Fact]
        public void Mapping_Should_Return_Proper_RoomDto()
        {
            var room = new Room { Id = Guid.NewGuid(), RoomNumber = 10, SeatsCount = 100 };

            var roomDto = this.mapper.Map<RoomDto>(room);

            Assert.Equal(room.Id, roomDto.Id);
            Assert.Equal(room.RoomNumber, roomDto.RoomNumber);
            Assert.Equal(room.SeatsCount, roomDto.SeatsCount);
        }
    }
}
