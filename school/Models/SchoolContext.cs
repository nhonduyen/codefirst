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
            //optionsBuilder.UseSqlServer("cnnstring");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}