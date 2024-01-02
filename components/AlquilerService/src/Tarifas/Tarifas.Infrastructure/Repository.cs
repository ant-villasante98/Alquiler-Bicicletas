
using Microsoft.EntityFrameworkCore;
using Tarifas.Domain;
using Tarifas.Domain.Repositories;
using Tarifas.Shared.Infrastructure.Persistence;

namespace Tarifas.Infrastructure;

public class TarifaRepository : ITarifaRepository
{
    private readonly AlquilerContext _context;

    public TarifaRepository(AlquilerContext context)
    {
        _context = context;
    }

    public async Task<List<Tarifa>> FindAll()
    {
        return await _context.Tarifas.ToListAsync();
    }

    public Task<Tarifa> FindById(TarifaId id)
    {
        throw new NotImplementedException();
    }
}