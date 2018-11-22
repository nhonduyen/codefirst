using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace school.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [MaxLength(30, ErrorMessage="Max 30"), MinLength(5, ErrorMessage="Min=5")]
        [Required]
        public string Name { get; set; }

        [Column("DOB", TypeName = "Date")]
        public DateTime? DOB { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public StudentAddress StudentAddress { get; set; }
        public Grade Grade { get; set; }
    }
}