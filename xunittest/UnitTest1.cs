using System;
using Microsoft.AspNetCore;
using Xunit;
using school.Models;
using school.Controllers;

namespace xunittest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public void ShouldReturnStudent()
        {
        //Given
        var student = new Student { Name="test", DOB=Convert.ToDateTime("2000-10-22") };
        var controller = new StudentController(new SchoolContext(
            new Microsoft.EntityFrameworkCore.DbContextOptions<SchoolContext>(
                
            )
        ));
        //When
        var students = controller.Get();
        //Then
      
        }
    }
}
