using MediatR;
using Microsoft.AspNetCore.Mvc;
using SYSRENT.Application.Features.Horario.Query;

namespace SYSRENT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HorarioController(IMediator _mediator) : ControllerBase
{

    [HttpGet("ListaCatHorario")]
    public async Task<IActionResult> ListaCatHorario()
    {
        return Ok(await _mediator.Send(new GetCatHorarioQuery()));
    }

}
