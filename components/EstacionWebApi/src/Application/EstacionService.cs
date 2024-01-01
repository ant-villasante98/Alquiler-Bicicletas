using Domain.CustomExeptions;
using Domain.Models;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services;

public class EstacionService : IEstacionService
{
    private readonly IEstacionRepository _repository;

    public EstacionService(IEstacionRepository repository)
    {
        _repository = repository;
    }

    public async Task<Estacion> Create(string nombre, double latitud, double longitud)
    {
        try
        {
            Estacion estacion = await _repository.Add(Estacion.Create(nombre, latitud, longitud));
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

    public async Task Update(long id, string nombre, double latitud, double longitud)
    {
        Estacion estacion = await this.GetById(id);
        try
        {
            estacion.Update(
                nombre,
                latitud,
                longitud
            );
            await _repository.Update(estacion);
        }
        catch (Exception)
        {
            throw new CouldNotUpdateDBException($"No se pudo actualizar la Estacion con id: {id}");
        }
    }
}
