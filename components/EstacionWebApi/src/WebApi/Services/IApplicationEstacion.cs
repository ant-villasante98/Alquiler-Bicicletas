using WebApi.Request;
using WebApi.Response;

namespace WebApi.Services;

public interface IApplicationEstacion
{
    Task<List<EstacionDto>> GetAll();

    Task<EstacionDto> Create(EstacionCreate model);

    Task<EstacionDto> GetById(long id);

    Task Delete(long id);

    Task Update(long id, EstacionDto estacionDto);
}
