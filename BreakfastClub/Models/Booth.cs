using System.ComponentModel.DataAnnotations;

namespace BreakfastClub.Models
{
    public class Booth
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BoothNumber { get; set; }
        [Required]
        public int Seats { get; set; }

        public bool isAvailable { get; set; } //is true based on Date

       /* public List<Reservation> BoothReservations { get; set; }*/

    }
}


// reservation has date, every time booth gets assigned to reservation, the reservation is added to the list, so when new reservation tries to assign booths
// booth will run checkAvailability(reservation.date) if reservation.date = in BoothReservations.date, booth isAvailable = false, booth goes grey in the list. 