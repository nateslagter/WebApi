using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repos;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepo _courseRepo;

    public CourseController(ICourseRepo courseRepo)
    {
        _courseRepo = courseRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Course>> GetCourses()
    {
        if (_courseRepo.GetCourses == null)
        {
            return NotFound();
        }
        return Ok(_courseRepo.GetCourses);
    }

    // GET: api/Assignments/5
    [HttpGet("{id}")]
    public ActionResult<Course> GetCourse(int id)
    {
        if (_courseRepo.GetCourses == null)
        {
            return NotFound();
        }

        return _courseRepo.GetCourse(id);
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

        _courseRepo.PostCourse(course);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult PutCourse(Course course)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (course.Id < 0)
        {
            return BadRequest(new ValidationProblemDetails());
        }


        _courseRepo.PutCourse(course);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCourse(int id)
    {
        if (id < 0)
        {
            return BadRequest(new ValidationProblemDetails());
        }

        _courseRepo.DeleteCourse(id);
        return Ok();
    }
}