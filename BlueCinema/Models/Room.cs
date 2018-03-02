using System;

namespace BlueCinema.Models
{
    public class Room
    {
        public Room()
        {
        }

        public Room(int roomNumber, int seatsCount)
        {
            RoomNumber = roomNumber;
            SeatsCount = seatsCount;
        }

        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public int SeatsCount { get; set; }

    }
}
