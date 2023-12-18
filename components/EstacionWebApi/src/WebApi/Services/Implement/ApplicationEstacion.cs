using AutoMapper;
using Domain.Models;
using Domain.Services;
using WebApi.Request;
using WebApi.Response;

namespace WebApi.Services.Implement;

public class ApplicationEstacion : IApplicationEstacion
{
    private readonly IEstacionService _estacionService;
    private readonly IMapper _mapper;

    public ApplicationEstacion(IEstacionService estacionService, IMapper mapper)
    {
        _estacionService = estacionService;
        _mapper = mapper;
    }

    public async Task<EstacionDto> Create(EstacionCreate model)
    {
        Estacion estacion = Estacion.Create(
            nombre: model.Nombre,
            latitud: model.Latitud,
            longitud: model.Longitud
        );

        Estacion savedEstacion = await _estacionService.Create(estacion);
        return _mapper.Map<Estacion, EstacionDto>(savedEstacion);
    }

    public async Task Delete(long id)
    {
        await _estacionService.Delete(id);
    }

    public async Task<List<EstacionDto>> GetAll()
    {
        List<Estacion> estaciones = await _estacionService.GetAll();
        return _mapper.Map<List<Estacion>, List<EstacionDto>>(estaciones);
    }

    public async Task<EstacionDto> GetById(long id)
    {
        Estacion estacion = await _estacionService.GetById(id);
        return _mapper.Map<Estacion, EstacionDto>(estacion);
    }

    public async Task Update(long id, EstacionDto estacionDto)
    {
        await _estacionService.Update(id, _mapper.Map<EstacionDto, Estacion>(estacionDto));
    }
}
