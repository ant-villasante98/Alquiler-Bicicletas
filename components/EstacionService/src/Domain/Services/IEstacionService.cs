using Domain.Models;

namespace Domain.Services;

public interface IEstacionService
{
    Task<Estacion> GetById(EstacionId id);
    Task<List<Estacion>> GetAll();
    Task<Estacion> Create(string nombre, EstacionLatitud latitud, EstacionLongitud longitud);
    Task Update(EstacionId id, string nombre, EstacionLatitud latitud, EstacionLongitud longitud);
    Task Delete(EstacionId id);
    Task<double> CalcularDistancia(EstacionId origenId, EstacionId destinoId);
}
