using System;

namespace FastX.DAL.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }

        public DateTime BookingDate { get; set; }

        public int SeatCount { get; set; }

        public decimal TotalFare { get; set; }

        public bool IsCancelled { get; set; }
    }
}
