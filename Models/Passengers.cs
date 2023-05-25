using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flyhigh_Airlines.Models
{
    public class Passengers
    {
        public int Pid { get; set; }
        public string? PName { get; set; }
        public int PNumber { get; set; }
        public string? PAddress { get; set; }

        [Key]
        public int BookingId { get; set; }
        public int NoOfSeats { get; set; }
        public Flights? Flight { get; set; } // Navigation property to Flight

    }
}
