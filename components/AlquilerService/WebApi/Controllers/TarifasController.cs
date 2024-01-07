using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tarifas.Application.Common;
using Tarifas.Application.Create;
using Tarifas.Application.Delete;
using Tarifas.Application.GetAll;
using Tarifas.Application.GetById;
using Tarifas.Application.Update;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/tarifas")]
public class TarifasController : ControllerBase
{
    private readonly IMediator _mediator;

    public TarifasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TarifaDto>>> GetAll()
    {
        try
        {
            var tarifas = await _mediator.Send(new GetAllTarifaQuery());
            return Ok(tarifas);
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TarifaDto>> GetById(long id)
    {
        var tarifa = await _mediator.Send(new GetByIdTarifaQuery(id));
        return Ok(tarifa);

    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTarifaCommand command)
    {
        var tarifaId = await _mediator.Send(command);
        return Created(nameof(GetById), null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdateTarifaCommand command)
    {
        if (id != command.Id) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _mediator.Send(new DeleteTarifaCommand(id));
        return NoContent();
    }
}
