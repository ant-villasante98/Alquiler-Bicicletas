using Domain.CustomExeptions;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Request;
using WebApi.Response;
using WebApi.Services;

[Route("api/[controller]")]
[ApiController]
public class EstacionesController : ControllerBase
{
    private readonly IApplicationEstacion _application;

    public EstacionesController(IApplicationEstacion application)
    {
        _application = application;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstacionDto>>> GetAll()
    {
        try
        {
            List<EstacionDto> estacionDtos = await _application.GetAll();
            return Ok(estacionDtos);
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<EstacionDto>> Create([FromBody] EstacionCreate estacion)
    {
        try
        {
            EstacionDto savedEstacion = await _application.Create(estacion);
            // TODO: Tambine se puede devolve el objeto creado
            return Created($"{Request.GetDisplayUrl()}/{savedEstacion.Id}", null);
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
            EstacionDto estacionDto = await _application.GetById(id);
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
            await _application.Delete(id);
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
    public async Task<IActionResult> Update(long id, [FromBody] EstacionDto estacion)
    {
        try
        {
            await _application.Update(id, estacion);
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
}
