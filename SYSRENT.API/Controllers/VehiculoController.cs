using Microsoft.AspNetCore.Mvc;

namespace SYSRENT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculoController : ControllerBase
{
    [HttpGet("Prueba")]
    public IActionResult Prueba()
    {
        return Ok("Hola");
    }
}
