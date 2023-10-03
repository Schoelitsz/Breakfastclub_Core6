using System.ComponentModel.DataAnnotations;
using System;

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
        [FutureDate]
        public DateTime Date {  get; set; }

        public List<Booth>  Booths { get; set; }


        /*public TimeOnly EndTime { get; set; }*/

        public class FutureDateAttribute : ValidationAttribute
        {
            public static ValidationResult ValidateDateInFuture(DateTime date, ValidationContext context)
            {
                if (date > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Datum moet in de toekomst zijn.");
                }
            }
        }
    }
}
