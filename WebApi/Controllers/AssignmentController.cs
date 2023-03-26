using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class AssignmentController : ControllerBase
{
    static List<Assignment> _assignments = new List<Assignment>
    {
        new Assignment{Id = 1, DueDate = DateTime.MaxValue, Grade = 100, ModuleId = 1, Name = "Assignment1ForModule1" },
        new Assignment{Id = 2, DueDate = DateTime.MaxValue, Grade = 0 , ModuleId = 2, Name = "Assignment1ForModule2"}
    };


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
    {
        if (_assignments == null)
        {
            return NotFound();
        }
        return Ok(_assignments);
    }

    // GET: api/Assignments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Assignment>> GetAssignment(int id)
    {
        if (_assignments == null || _assignments.FirstOrDefault(i => i.Id == id) == null)
        {
            return NotFound();
        }

        return _assignments.FirstOrDefault(i => i.Id == id);
    }

    [HttpPost]
    public async Task<IActionResult> PostAssignment(Assignment assignment)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (assignment.Id < 0) 
        {
            return BadRequest(new ValidationProblemDetails());
        }

        _assignments.Add(assignment);
        return Ok(_assignments);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAssignment(Assignment assignment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (assignment.Id < 0 || assignment.Id > _assignments.Count)
        {
            return BadRequest(new ValidationProblemDetails());
        }


        Assignment assignmentToRemove = _assignments.FirstOrDefault(i => i.Id == assignment.Id);
        _assignments.Remove(assignmentToRemove);
        _assignments.Add(assignment);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignment(int id)
    {
        if (id < 0 || id > _assignments.Count)
        {
            return BadRequest(new ValidationProblemDetails());
        }

        Assignment assignmentToRemove = _assignments.FirstOrDefault(i => i.Id == id);
        _assignments.Remove(assignmentToRemove);
        return Ok();
    }
}