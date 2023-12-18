using Domain.Models;

namespace Domain.Services;

public interface IEstacionService
{
    Task<Estacion> GetById(long id);
    Task<List<Estacion>> GetAll();
    Task<Estacion> Create(Estacion model);
    Task Update(long id, Estacion model);
    Task Delete(long id);
}
