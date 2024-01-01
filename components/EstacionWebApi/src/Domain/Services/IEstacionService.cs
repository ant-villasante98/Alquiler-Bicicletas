using Domain.Models;

namespace Domain.Services;

public interface IEstacionService
{
    Task<Estacion> GetById(long id);
    Task<List<Estacion>> GetAll();
    Task<Estacion> Create(string nombre, double latitud, double longitud);
    Task Update(long id, string nombre, double latitud, double longitud);
    Task Delete(long id);
}
