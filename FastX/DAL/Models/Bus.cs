namespace FastX.DAL.Models
{
    public class Bus
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BusNumber { get; set; }

        public string Type { get; set; } // Sleeper, AC, Non-AC, etc.

        public int SeatCount { get; set; }

        public string Amenities { get; set; } // CSV: "TV,Water,Charging"

        public ICollection<Route> Routes { get; set; }
    }
}
