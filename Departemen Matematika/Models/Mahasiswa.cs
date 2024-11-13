using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Departemen_Matematika.Models
{
    public class Mahasiswa
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Input NIM!")]
        public string? NIM { get; set; }

        [Required(ErrorMessage = "Please Input Nama!")]
        public string?  Nama { get; set; }

        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please Input Telephone!")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Please Input Address")]
        public string? Address { get; set; }

        public DateTime? Join_Date { get; set; }

        public DateTime? Graduation_Date { get; set; }

        public string? Dosen_Wali { get; set; }

        public string? Fakultas_Code { get; set; }

        public string? Department_Code { get; set; }
    }
}
