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
        public async Task<ActionResult<List<Student>>> Get()
        {
            var students = await _shoolContext.Students.ToListAsync().ConfigureAwait(false);
            if (students == null)
            {
                return NotFound();
            }
            return new OkObjectResult(students);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _shoolContext.Students.Where(c => c.StudentId == id).FirstOrDefaultAsync()
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