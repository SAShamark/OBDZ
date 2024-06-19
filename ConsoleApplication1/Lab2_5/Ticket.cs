using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Class { get; set; }
        public decimal Price { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}