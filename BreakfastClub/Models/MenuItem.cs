using System.ComponentModel.DataAnnotations;

namespace BreakfastClub.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }

        [Required]
        public string Course { get; set; }
    }
}
