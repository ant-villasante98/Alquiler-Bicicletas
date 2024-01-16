using Application.CalcularDistancia;
using Application.Common;
using Application.Create;
using Application.Delete;
using Application.GetAll;
using Application.GetById;
using Application.Update;
using Domain.CustomExeptions;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/v1/estaciones")]
[ApiController]
public class EstacionesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EstacionesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstacionDto>>> GetAll()
    {
        try
        {
            //List<EstacionDto> estacionDtos = await _application.GetAll();
            var estacionDtos = await _mediator.Send(new EstacionesGetAllQuery());
            return Ok(estacionDtos);
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EstacionCreateCommand command)
    {
        try
        {
            //EstacionDto savedEstacion = await _application.Create(estacion);
            // TODO: Tambine se puede devolve el objeto creado
            var savedEstacionId = await _mediator.Send(command);
            return Created($"{Request.GetDisplayUrl()}/{savedEstacionId}", null);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EstacionDto>> GetById(long id)
    {
        try
        {
            //EstacionDto estacionDto = await _application.GetById(id);
            var estacionDto = await _mediator.Send(new EstacionGetByIdQuery(id));
            return Ok(estacionDto);
        }
        catch (System.Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            //await _application.Delete(id);
            await _mediator.Send(new EstacionDeleteCommand(id));
            return NoContent();
        }
        catch (CouldNotUpdateDBException ex)
        {
            // TODO: especificar el error
            return Conflict(ex.Message);
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] EstacionUpdateCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("El id de la ruta del cuerpo son diferentes.");
        }
        try
        {
            //await _application.Update(id, estacion);
            await _mediator.Send(command);
            return NoContent();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch (CouldNotUpdateDBException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet("calcular-distancia")]
    public async Task<ActionResult<DistanciaResponse>> CalcularDistancia([FromQuery()] long origen, [FromQuery] long destino)
    {
        DistanciaResponse distancia = await _mediator.Send(new CalcularDistanciaEstacionCommand(origen, destino));
        return Ok(distancia);
    }
}
