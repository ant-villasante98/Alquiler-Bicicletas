using Tarifas.Domain;
using Tarifas.Domain.Repositories;
using Tarifas.Domain.Services;

namespace Tarifas.Application;
public class TarifaService : ITarifaService
{
    private readonly ITarifaRepository _repository;

    public TarifaService(ITarifaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Tarifa>> GetAll()
    {
        return await _repository.FindAll();
    }

    public async Task<Tarifa> GetById(TarifaId id)
    {
        return await _repository.FindById(id);
    }
}
