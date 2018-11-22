using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace school.Models {
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(
                sc => new { sc.StudentId, sc.CourseId }
            );
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddress { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Grade> Grade { get; set; }
    }
}