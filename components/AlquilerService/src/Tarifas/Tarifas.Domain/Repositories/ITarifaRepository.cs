
namespace Tarifas.Domain.Repositories;

public interface ITarifaRepository
{
    Task<Tarifa> FindById(TarifaId id);
    Task<List<Tarifa>> FindAll();
}