using System.ComponentModel.DataAnnotations;

namespace Flyhigh_Airlines.Models
{
    public class Flights
    {
        [Key]
        public int Fid { get; set; }
        public string? FName { get; set; }
        public int SeatAvailability { get; set; }
        public string? YourLocation { get; set; }
        public string? Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public decimal Price { get; set; }
        public ICollection<Passengers>? Passengers { get; set; } // Navigation property to Passenger

    }
}
