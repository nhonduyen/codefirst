using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school.Models
{
    public class StudentAddress
    {
        [Key]
        public int AddressId { get; set; }

        [MaxLength(30, ErrorMessage="Max 50"), MinLength(5, ErrorMessage="Min=5")]
        [Required]
        public string Address { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}