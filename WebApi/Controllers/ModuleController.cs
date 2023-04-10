using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repos;

[Route("api/[controller]")]
[ApiController]
public class ModuleController : ControllerBase
{
    private readonly IModuleRepo _moduleRepo;

    public ModuleController(IModuleRepo moduleRepo)
    {
        _moduleRepo = moduleRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Module>> GetModules()
    {
        if (_moduleRepo.GetModules == null)
        {
            return NotFound();
        }
        return Ok(_moduleRepo.GetModules);
    }

    // GET: api/Assignments/5
    [HttpGet("{id}")]
    public ActionResult<Module> GetModule(int id)
    {
        if (_moduleRepo.GetModules == null )
        {
            return NotFound();
        }

        return _moduleRepo.GetModule(id);
    }

    [HttpPost]
    public ActionResult PostModule(Module module)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (module.Id < 0)
        {
            return BadRequest(new ValidationProblemDetails());
        }

        _moduleRepo.PostModule(module);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult PutModule(Module module)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        if (module.Id < 0)
        {
            return BadRequest(new ValidationProblemDetails());
        }


        _moduleRepo.PutModule(module);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteModule(int id)
    {
        if (id < 0)
        {
            return BadRequest(new ValidationProblemDetails());
        }

        _moduleRepo.DeleteModule(id);
        return Ok();
    }
}