using MediatR;
using Microsoft.AspNetCore.Mvc;
using SYSRENT.Application.Features.Vehiculo.Command;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculoController(IMediator _mediator) : ControllerBase
{
    [HttpGet("Prueba")]
    public IActionResult Prueba()
    {
        return Ok("Hola");
    }

    [HttpPost("AgregarVehiculo")]
    public async Task<IActionResult> AgregarVehiculo([FromBody] VEHICULO Vehiculo)
    {
        return Ok(await _mediator.Send(new AddVehiculoCommand(Vehiculo)));
    }

}
