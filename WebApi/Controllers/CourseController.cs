using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    List<Course> _courses = new List<Course>
    {
        new Course { Id = 1, Name = "Nate's Amazing Class"}
    };


    [HttpGet]
    public ActionResult<IEnumerable<Assignment>> GetCourses()
    {
        if (_courses == null)
        {
            return NotFound();
        }
        return Ok(_courses);
    }

    // GET: api/Assignments/5
    [HttpGet("{id}")]
    public ActionResult<Course> GetCourse(int id)
    {
        if (_courses == null || _courses.FirstOrDefault(i => i.Id == id) == null)
        {
            return NotFound();
        }

        return _courses.FirstOrDefault(i => i.Id == id);
    }

    [HttpPost]
    public ActionResult PostCourse(Course course)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (course.Id < 0)
        {
            return BadRequest(new ValidationProblemDetails());
        }

        _courses.Add(course);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult PutCourse(Course course)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (course.Id < 0 || course.Id > _courses.Count)
        {
            return BadRequest(new ValidationProblemDetails());
        }


        Course courseToRemove = _courses.FirstOrDefault(i => i.Id == course.Id);
        _courses.Remove(courseToRemove);
        _courses.Add(course);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCourse(int id)
    {
        if (id < 0 || id > _courses.Count)
        {
            return BadRequest(new ValidationProblemDetails());
        }

        Course courseToRemove = _courses.FirstOrDefault(i => i.Id == id);
        _courses.Remove(courseToRemove);
        return Ok();
    }
}