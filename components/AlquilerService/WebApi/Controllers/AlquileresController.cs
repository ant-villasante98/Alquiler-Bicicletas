
using Alquileres.Application.Common;
using Alquileres.Application.Create;
using Alquileres.Application.Finish;
using Alquileres.Application.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/v1/alquileres")]
public class AlquileresController : ControllerBase
{
    private readonly IMediator _mediator;

    public AlquileresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("iniciar-alquiler")]
    public async Task<ActionResult<AlquilerResponse>> StartAlquiler([FromBody] CreateAlquilerCommand command)
    {
        CreateAlquilerCommand commandWhitCliente = command with { Cliente = Guid.NewGuid().ToString() };
        var alquiler = await _mediator.Send(commandWhitCliente);
        return Created($"{alquiler.Id}", alquiler);
    }

    [HttpPatch("finalizar-alquiler/{id}")]
    public async Task<IActionResult> FinishAlquiler(long id, [FromBody] FinishAlquilerCommand command)
    {
        if (id != command.AlquilerId) return BadRequest("El id del cuerpo y el PathRequest");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlquilerResponse>>> GetAll()
    {
        var alquileres = await _mediator.Send(new GetAllAlquilerCommand());
        return Ok(alquileres);
    }
}