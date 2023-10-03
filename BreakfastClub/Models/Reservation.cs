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
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date {  get; set; }

        /*public List<Booth>  Booths { get; set; }*/


        /*public TimeOnly EndTime { get; set; }*/

        public class FutureDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is DateTime date)
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

                return new ValidationResult("Ongeldige datumwaarde.");
            }
        }
    }
}
