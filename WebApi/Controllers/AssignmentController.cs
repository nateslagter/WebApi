using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Models;
using WebApi.Repos;

[Route("api/[controller]")]
[ApiController]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentRepo? _assignmentRepo;

    public AssignmentController(IAssignmentRepo? assignmentRepo)
    {
        _assignmentRepo = assignmentRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Assignment>> GetAssignments()
    {
        List<Assignment> assignments = new List<Assignment>();
        assignments = _assignmentRepo.GetAssignments();
        if (assignments == null)
        {
            return NotFound();
        }
        return Ok(assignments);
    }

    // GET: api/Assignments/5
    [HttpGet("{id}")]
    public ActionResult<Assignment> GetAssignment(int id)
    {
        Assignment assignment = _assignmentRepo.GetAssignment(id);
        if (assignment == null)
        {
            return NotFound();
        }

        return assignment;
    }

    [HttpPost]
    public ActionResult PostAssignment([FromBody] Assignment assignment)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }
        _assignmentRepo.PostAssignment(assignment);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult PutAssignment(Assignment assignment)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }
        _assignmentRepo.PutAssignment(assignment);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAssignment(int id)
    {
        if (_assignmentRepo.GetAssignment(id) == null)
        {
            return BadRequest();
        }
        _assignmentRepo.DeleteAssignment(id);
        return Ok();
    }
}