using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Train
    {
        public int TrainId { get; set; }
        public string TrainNumber { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}