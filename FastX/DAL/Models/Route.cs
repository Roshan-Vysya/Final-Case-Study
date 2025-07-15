using System;

namespace FastX.DAL.Models
{
    public class Route
    {
        public int Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal Fare { get; set; }

        public int BusId { get; set; }

        public Bus Bus { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
