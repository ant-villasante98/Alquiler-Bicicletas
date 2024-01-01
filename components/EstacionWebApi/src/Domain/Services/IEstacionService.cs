using Domain.Models;

namespace Domain.Services;

public interface IEstacionService
{
    Task<Estacion> GetById(EstacionId id);
    Task<List<Estacion>> GetAll();
    Task<Estacion> Create(string nombre, double latitud, double longitud);
    Task Update(EstacionId id, string nombre, double latitud, double longitud);
    Task Delete(EstacionId id);
}
