using System;

namespace BlueCinema.Exceptions
{
    public class SeanceException
    {
    }

    public class BookingException : Exception
    {
        public BookingException(string message) : base(message)
        {

        }
    }
}
