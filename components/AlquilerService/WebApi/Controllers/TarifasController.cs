using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Tarifas.Application.Common;
using Tarifas.Application.GetAll;

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
    public async Task<ActionResult<IEnumerable<TarifaResponse>>> GetAll()
    {
        try
        {
            var tarifas = await _mediator.Send(new GetAllTarifaCommand());
            return Ok(tarifas);
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }
}
