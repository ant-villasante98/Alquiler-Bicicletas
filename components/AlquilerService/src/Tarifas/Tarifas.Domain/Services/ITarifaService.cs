
namespace Tarifas.Domain.Services;

public interface ITarifaService
{
    Task<Tarifa> GetById(TarifaId id);
    Task<List<Tarifa>> GetAll();
}