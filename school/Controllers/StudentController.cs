using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using school.Models;
using Microsoft.EntityFrameworkCore;

namespace school.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private SchoolContext _shoolContext;
        public StudentController(SchoolContext context)
        {
            _shoolContext = context;
        }
         // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
       
            var result = await ( from s in _shoolContext.Students
            join g in _shoolContext.Grade
            on s.Grade.GradeId equals g.GradeId
            join stdadd in _shoolContext.StudentAddress
            on s.StudentAddress.StudentId equals stdadd.StudentId
            join sc in _shoolContext.StudentCourse
            on s.StudentId equals sc.StudentId
            join c in _shoolContext.Courses
            on sc.CourseId equals c.CourseId
            select new {
                Students = new {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Grade = g.GradeName,
                    DOB = s.DOB,
                    StudentAddress = stdadd.Address,
                    Course = new 
                    {
                        CourseId = sc.CourseId,
                        CourseName = sc.Course.CourseName
                    }
                }
            }
            ).ToListAsync();
           
            if (result == null)
            {
                return NotFound();
            }
            /*
            var studentJoins = await _shoolContext.Students.AsNoTracking().FromSql(@"
            select * from Students as s
            inner join Grade as g
            on s.GradeId = g.GradeId
            inner join StudentAddress as sa
            on sa.StudentId = s.StudentId
            inner join StudentCourse as sc
            on s.StudentId = sc.StudentId
			inner join Course as c
			on sc.CourseId = c.CourseId
            ").ToListAsync();
            //var students = await _shoolContext.Students.ToListAsync().ConfigureAwait(false);
         */
            return new OkObjectResult(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _shoolContext.Students.AsNoTracking().Where(c => c.StudentId == id).FirstOrDefaultAsync()
            .ConfigureAwait(false);
            if (student == null)
            {
                return NotFound();
            }
            return new OkObjectResult(student);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            _shoolContext.Students.Add(student);
            var effectedRows = await _shoolContext.SaveChangesAsync().ConfigureAwait(false);

            return new OkObjectResult(effectedRows);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Student student)
        {
            _shoolContext.Students.Update(student);
            var effectedRows = await _shoolContext.SaveChangesAsync().ConfigureAwait(false);

            return new OkObjectResult(effectedRows);
        }

        [HttpPut]
        [Route("PutSampleData")]
        public async Task<IActionResult> PutSampleData()
        {
            var grades = new List<Grade> 
           {
               new Grade { GradeName = "A" },
               new Grade { GradeName = "B" },
               new Grade { GradeName = "C" }
           };
           var students = new List<Student> 
           {
               new Student { Name = "Nguyen" , DOB = Convert.ToDateTime("1990-08-09"), StudentAddress = new StudentAddress { Address = "Address 1"}, Grade = grades[0] },
               new Student { Name = "Nhon" , DOB = Convert.ToDateTime("1990-09-09") , StudentAddress = new StudentAddress { Address = "Address 2"}, Grade = grades[1] },
               new Student { Name = "Duyen" , DOB = Convert.ToDateTime("1990-10-09"), StudentAddress = new StudentAddress { Address = "Address 3"}, Grade = grades[2] }
           };
            var courses = new List<Course> 
           {
               new Course { CourseName = "Course 1" },
               new Course { CourseName = "Course 2" },
               new Course { CourseName = "Course 3" }
           };
          
            _shoolContext.AddRange(students);
            _shoolContext.AddRange(courses);
            _shoolContext.AddRange(grades);
            var studentCourse = new List<StudentCourse>
            {
                new StudentCourse { StudentId = students[0].StudentId, CourseId = courses[0].CourseId },
                new StudentCourse { StudentId = students[1].StudentId, CourseId = courses[1].CourseId },
                new StudentCourse { StudentId = students[2].StudentId, CourseId = courses[2].CourseId }
            };
            _shoolContext.AddRange(studentCourse);
            var effectedRows1 = await _shoolContext.SaveChangesAsync().ConfigureAwait(false);
            return new OkObjectResult(effectedRows1);
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removeStudent = _shoolContext.Students.Where(course => course.StudentId == id)
            .FirstOrDefaultAsync();
            if (removeStudent == null)
            {
                return NotFound();
            }
            _shoolContext.Students.Remove(removeStudent.GetAwaiter().GetResult());
            var effectedRows = await _shoolContext.SaveChangesAsync().ConfigureAwait(false);

            return new OkObjectResult(effectedRows);
        }
    }
}