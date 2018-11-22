using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace school.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [MaxLength(30, ErrorMessage="Max 30"), MinLength(5, ErrorMessage="Min=5")]
        [Required]
        public string CourseName { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}