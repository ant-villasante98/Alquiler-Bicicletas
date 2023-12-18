using Domain.CustomExeptions;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;

namespace Domain.Service.Implement;

public class EstacionService : IEstacionService
{
    private readonly IEstacionRepository _repository;

    public EstacionService(IEstacionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Estacion> Create(Estacion model)
    {
        try
        {
            Estacion estacion = await _repository.Add(model);
            return estacion;
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex);
            throw new CouldNotUpdateDBException("No se pudo agregar la Estacion.");
        }
    }

    public async Task Delete(long id)
    {
        Estacion estacion = await this.GetById(id);
        try
        {
            await _repository.Delete(estacion);
        }
        catch (Exception)
        {
            throw new CouldNotUpdateDBException($"No se pudo eliminar la Estacion con id: {id}");
        }
    }

    public async Task<List<Estacion>> GetAll()
    {
        List<Estacion> estaciones = await _repository.FindAll();
        return estaciones;
    }

    public async Task<Estacion> GetById(long id)
    {
        Estacion estacion =
            await _repository.FindbyId(id)
            ?? throw new NullReferenceException($"No se pudo encontrar la Estcion con id: {id}");
        return estacion;
    }

    public async Task Update(long id, Estacion model)
    {
        Estacion originalEstacion = await this.GetById(id);
        try
        {
            Estacion estacion = new Estacion(
                id,
                model.Nombre,
                originalEstacion.FechaHoraCreacion,
                model.Latitud,
                model.Longitud
            );
            await _repository.Update(estacion);
        }
        catch (Exception)
        {
            throw new CouldNotUpdateDBException($"No se pudo actualizar la Estacion con id: {id}");
        }
    }
}
