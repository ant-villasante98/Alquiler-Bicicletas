
namespace Tarifas.Domain.Repositories;

public interface ITarifaRepository
{
    Task<Tarifa> FindById(TarifaId id);
    Task<List<Tarifa>> FindAll();

    Task Delete(Tarifa tarifa);
    Task Update(Tarifa tarifa);
    Task<Tarifa> Add(Tarifa tarifa);
}