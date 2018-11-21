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
    public class CourseController : ControllerBase
    {
        private SchoolContext _shoolContext;
        public CourseController(SchoolContext context)
        {
            _shoolContext = context;
        }
         // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<Course>>> Get()
        {
            var courses = await _shoolContext.Courses.ToListAsync().ConfigureAwait(false);
            if (courses == null)
            {
                return NotFound();
            }
            return new OkObjectResult(courses);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var course = await _shoolContext.Courses.Where(c => c.CourseId == id).FirstOrDefaultAsync()
            .ConfigureAwait(false);
            if (course == null)
            {
                return NotFound();
            }
            return new OkObjectResult(course);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            _shoolContext.Courses.Add(course);
            var effectedRows = await _shoolContext.SaveChangesAsync().ConfigureAwait(false);

            return new OkObjectResult(effectedRows);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Course course)
        {
            _shoolContext.Courses.Update(course);
            var effectedRows = await _shoolContext.SaveChangesAsync().ConfigureAwait(false);

            return new OkObjectResult(effectedRows);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removeCoures = _shoolContext.Courses.Where(course => course.CourseId == id)
            .FirstOrDefaultAsync();
            if (removeCoures == null)
            {
                return NotFound();
            }
            _shoolContext.Courses.Remove(removeCoures.GetAwaiter().GetResult());
            var effectedRows = await _shoolContext.SaveChangesAsync().ConfigureAwait(false);

            return new OkObjectResult(effectedRows);
        }
    }
}