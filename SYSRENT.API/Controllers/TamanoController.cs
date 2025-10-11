using MediatR;
using Microsoft.AspNetCore.Mvc;
using SYSRENT.Application.Features.Horario.Query;
using SYSRENT.Application.Features.Tamano.Query;

namespace SYSRENT.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TamanoController(IMediator _mediator) : ControllerBase
{

    [HttpGet("ListaCatTamano")]
    public async Task<IActionResult> ListaCatTamano()
    {
        return Ok(await _mediator.Send(new GetCatTamanoQuery()));
    }

}
