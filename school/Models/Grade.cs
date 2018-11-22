using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [MaxLength(30, ErrorMessage="Max 50"), MinLength(5, ErrorMessage="Min=5")]
        [Required]
        public string GradeName { get; set; }
    }
}