using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ModuleController : ControllerBase
{
    static List<Module> _modules = new List<Module>
    {
        new Module{Id = 1, Name = "CS420Week1", CourseId = 1,}
    };


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Module>>> GetModules()
    {
        if (_modules == null)
        {
            return NotFound();
        }
        return Ok(_modules);
    }

    // GET: api/Assignments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Module>> GetModule(int id)
    {
        if (_modules == null || _modules.FirstOrDefault(i => i.Id == id) == null)
        {
            return NotFound();
        }

        return _modules.FirstOrDefault(i => i.Id == id);
    }

    [HttpPost]
    public async Task<IActionResult> PostModule(Module module)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (module.Id < 0)
        {
            return BadRequest(new ValidationProblemDetails());
        }

        _modules.Add(module);
        return Ok(_modules);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutModule(Module module)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (module.Id < 0 || module.Id > _modules.Count)
        {
            return BadRequest(new ValidationProblemDetails());
        }


        Module moduleToRemove = _modules.FirstOrDefault(i => i.Id == module.Id);
        _modules.Remove(moduleToRemove);
        _modules.Add(module);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteModule(int id)
    {
        if (id < 0 || id > _modules.Count)
        {
            return BadRequest(new ValidationProblemDetails());
        }

        Module moduleToRemove = _modules.FirstOrDefault(i => i.Id == id);
        _modules.Remove(moduleToRemove);
        return Ok();
    }
}