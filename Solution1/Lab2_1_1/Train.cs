using System;

namespace Lab2_1_1
{
    internal class Train
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }
    }
}