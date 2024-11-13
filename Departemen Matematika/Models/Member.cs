using System.ComponentModel.DataAnnotations;

namespace Departemen_Matematika.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nama")]
        public string Name { get; set; }

        [Required]
        [StringLength(14)]
        public string NIM { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
