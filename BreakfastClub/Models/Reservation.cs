using System.ComponentModel.DataAnnotations;

namespace BreakfastClub.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int ReservationSeats { get; set; }

        [Required]
        public DateTime Date {  get; set; }
    }
}


// add date is > than now validation