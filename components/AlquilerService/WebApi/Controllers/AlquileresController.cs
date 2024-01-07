
using Alquileres.Application.Common;
using Alquileres.Application.Create;
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

    [HttpPost]
    public async Task<ActionResult<AlquilerResponse>> StartAlquiler([FromBody] CreateAlquilerCommand command)
    {
        CreateAlquilerCommand commandWhitCliente = command with { Cliente = Guid.NewGuid().ToString() };
        var alquiler = await _mediator.Send(commandWhitCliente);
        return Created($"{alquiler.Id}", alquiler);
    }
}